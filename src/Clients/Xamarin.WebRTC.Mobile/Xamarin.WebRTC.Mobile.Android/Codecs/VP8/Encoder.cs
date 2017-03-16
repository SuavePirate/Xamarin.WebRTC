using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FM;

namespace Xamarin.WebRTC.Mobile.Android.Codecs.VP8
{
    public class Encoder
    {
        private LibVpxEnc Codec;
        private LibVpxEncConfig Config;
        private int FrameCount;
        private int MaxFramerate;
        private bool SendKeyframe;

        private int _Bitrate;
        private double _Quality;
        private int _MaxQuantizer;

        public int Bitrate
        {
            get { return _Bitrate; }
            set { _Bitrate = value; }
        }
        public double Quality
        {
            get { return _Quality; }
            set
            { 
                _Quality = (value < 0.0 ? 0.0 : (value > 1.0 ? 1.0 : value));

                int lowerBound = 31;
                int upperBound = 63;
                _MaxQuantizer = lowerBound + (int)((1.0 - _Quality) * (upperBound - lowerBound));
            }
        }

        public Encoder()
        {
            FrameCount = 0;
            MaxFramerate = 30;

            Quality = 0.5;
            Bitrate = 320;
        }

        public byte[] Encode(int width, int height, byte[] frame, long fourcc, int rotation)
        {
            try
            {
                if (Codec != null && (width != Config.getWidth() || height != Config.getHeight() || _Bitrate != Config.getRCTargetBitrate() || _MaxQuantizer != Config.getRCMaxQuantizer()))
                {
                    if (Codec != null)
                    {
                        Codec.close();
                        Codec = null;
                    }

                    if (Config != null)
                    {
                        Config.close();
                        Config = null;
                    }
                }

                if (Codec == null)
                {
                    // define configuration options
                    Config = new LibVpxEncConfig(width, height);
                    Config.setTimebase(1, 30);
                    Config.setRCTargetBitrate(_Bitrate);
                    Config.setRCEndUsage(1); // vpx_rc_mode.VPX_CBR
                    //Config.setKFMode(1); // vpx_kf_mode.VPX_KF_AUTO
                    Config.setKFMinDist(30 * 60); // 1 per min @ 30fps
                    Config.setKFMaxDist(30 * 60); // 1 per min @ 30fps
                    Config.setErrorResilient(1);
                    Config.setLagInFrames(0);
                    Config.setPass(0); // vpx_enc_pass.VPX_RC_ONE_PASS
                    Config.setRCMinQuantizer(0);
                    Config.setRCMaxQuantizer(_MaxQuantizer);
                    Config.setProfile(0);

                    // initialize encoder
                    Codec = new LibVpxEnc(Config);

                    // additional tuning
                    int VP8_ONE_TOKENPARTITION = 0;
                    Codec.setStaticThreshold(1);
                    Codec.setCpuUsed(-12); // only on mobile
                    Codec.setTokenPartitions(VP8_ONE_TOKENPARTITION);
                    Codec.setNoiseSensitivity(0);
                    Codec.setMaxIntraBitratePct(Math.Min(300, (int)(Config.getRCBufOptimalSz() * 0.5f * MaxFramerate / 10)));
                }

                // set flags
                long flag = 0;
                if (SendKeyframe)
                {
                    flag |= (1 << 0); // VPX_EFLAG_FORCE_KF;
                    SendKeyframe = false;
                }

                // encode
                long deadline = 1; // VPX_DL_REALTIME
                long duration = 90000 / MaxFramerate;
                var buffer = Codec.convertByteEncodeFrame(frame, FrameCount, duration, flag, deadline, fourcc, rotation);

                FrameCount++;

                // get frame
                return buffer;
            }
            catch (Exception ex)
            {
                Log.Error("Could not encode frame.", ex);
            }

            return null;
        }

        public void ForceKeyframe()
        {
            SendKeyframe = true;
        }

        public void Destroy()
        {
            try
            {
                if (Codec != null)
                {
                    Codec.close();
                    Codec = null;
                }

                if (Config != null)
                {
                    Config.close();
                    Config = null;
                }
            }
            catch (Exception) { }
        }
    }
}