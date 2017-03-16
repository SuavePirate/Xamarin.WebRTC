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
using FM.IceLink.WebRTC;

namespace Xamarin.WebRTC.Mobile.Android.Codecs.VP8
{
    public class Decoder
    {
        private LibVpxDec Codec;
        public bool NeedsKeyFrame;

        public Decoder()
        {
            // initialize decoder
            Codec = new LibVpxDec();
        }

        public byte[] Decode(byte[] encodedFrame, out int width, out int height)
        {
            // decode
            byte[] data;
            try
            {
                var widthHeight = new int[2];
                var result = new int[1];
                data = Codec.decodeFrameToBuffer(encodedFrame, widthHeight, result);
                if (result[0] == 5)
                {
                    NeedsKeyFrame = true;
                }
                else
                {
                    NeedsKeyFrame = false;

                    // get frame
                    if (data != null)
                    {
                        width = widthHeight[0];
                        height = widthHeight[1];
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Could not decode frame.", ex);
            }

            width = 0;
            height = 0;
            return null;
        }

        public void Destroy()
        {
            try
            {
                Codec.close();
            }
            catch (Exception) { }
        }
    }
}