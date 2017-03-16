using System;
using System.Runtime.InteropServices;

using Android.Runtime;

namespace Xamarin.WebRTC.Mobile.Android.Codecs.VP8
{
    class LibVpxEncConfig : LibVpxCom
    {
        private long encCfgObj;

        [DllImport(LibVpxCom.DllPath)]
        private static extern long Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncAllocCfg(IntPtr env, IntPtr jniClass);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncFreeCfg(IntPtr env, IntPtr jniClass, long cfg);

        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncConfigDefault(IntPtr env, IntPtr jniClass, long cfg, int argUsage);

        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetUsage(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetThreads(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetProfile(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetWidth(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetHeight(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetTimebase(IntPtr env, IntPtr jniClass, long cfg, int num, int den);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetErrorResilient(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetPass(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetLagInFrames(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCDropframeThresh(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCResizeAllowed(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCResizeUpThresh(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCResizeDownThresh(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCEndUsage(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCTargetBitrate(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCMinQuantizer(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCMaxQuantizer(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCUndershootPct(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCOvershootPct(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCBufSz(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCBufInitialSz(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCBufOptimalSz(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRC2PassVBRBiasPct(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRC2PassVBRMinsectionPct(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRC2PassVBRMaxsectioniasPct(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetKFMinDist(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetKFMaxDist(IntPtr env, IntPtr jniClass, long cfg, int value);

        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetUsage(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetThreads(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetProfile(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetWidth(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetHeight(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern Rational Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetTimebase(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetErrorResilient(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetPass(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetLagInFrames(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCDropframeThresh(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCResizeAllowed(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCResizeUpThresh(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCResizeDownThresh(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCEndUsage(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCTargetBitrate(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCMinQuantizer(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCMaxQuantizer(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCUndershootPct(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCOvershootPct(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCBufSz(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCBufInitialSz(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCBufOptimalSz(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRC2PassVBRBiasPct(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRC2PassVBRMinsectionPct(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRC2PassVBRMaxsectioniasPct(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetKFMode(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetKFMinDist(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetKFMaxDist(IntPtr env, IntPtr jniClass, long cfg);

        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetFourcc(IntPtr env, IntPtr jniClass);

        public LibVpxEncConfig(int width, int height)
        {
            encCfgObj = Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncAllocCfg(JNIEnv.Handle, IntPtr.Zero);
            if (encCfgObj == 0)
            {
                throw new LibVpxException("Can not allocate JNI encoder configure object");
            }

            int res = Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncConfigDefault(JNIEnv.Handle, IntPtr.Zero, encCfgObj, 0);
            if (res != 0)
            {
                Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncFreeCfg(JNIEnv.Handle, IntPtr.Zero, encCfgObj);
                throw new LibVpxException(errToString(res));
            }

            setWidth(width);
            setHeight(height);

            /* Change the default timebase to a high enough value so that the encoder
             * will always create strictly increasing timestamps.
             */
            setTimebase(1, 1000);
        }

        public void close()
        {
            Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncFreeCfg(JNIEnv.Handle, IntPtr.Zero, encCfgObj);
        }

        public long handle()
        {
            return encCfgObj;
        }

        public void setThreads(int value)
        {
            Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetThreads(JNIEnv.Handle, IntPtr.Zero, encCfgObj, value);
        }

        public void setProfile(int value)
        {
            Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetProfile(JNIEnv.Handle, IntPtr.Zero, encCfgObj, value);
        }

        public void setWidth(int value)
        {
            Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetWidth(JNIEnv.Handle, IntPtr.Zero, encCfgObj, value);
        }

        public void setHeight(int value)
        {
            Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetHeight(JNIEnv.Handle, IntPtr.Zero, encCfgObj, value);
        }

        public void setTimebase(int num, int den)
        {
            Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetTimebase(JNIEnv.Handle, IntPtr.Zero, encCfgObj, num, den);
        }

        public void setErrorResilient(int value)
        {
            Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetErrorResilient(JNIEnv.Handle, IntPtr.Zero, encCfgObj, value);
        }

        public void setPass(int value)
        {
            Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetPass(JNIEnv.Handle, IntPtr.Zero, encCfgObj, value);
        }

        public void setLagInFrames(int value)
        {
            Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetLagInFrames(JNIEnv.Handle, IntPtr.Zero, encCfgObj, value);
        }

        public void setRCDropframeThresh(int value)
        {
            Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCDropframeThresh(JNIEnv.Handle, IntPtr.Zero, encCfgObj, value);
        }

        public void setRCResizeAllowed(int value)
        {
            Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCResizeAllowed(JNIEnv.Handle, IntPtr.Zero, encCfgObj, value);
        }

        public void setRCResizeUpThresh(int value)
        {
            Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCResizeUpThresh(JNIEnv.Handle, IntPtr.Zero, encCfgObj, value);
        }

        public void setRCResizeDownThresh(int value)
        {
            Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCResizeDownThresh(JNIEnv.Handle, IntPtr.Zero, encCfgObj, value);
        }

        public void setRCEndUsage(int value)
        {
            Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCEndUsage(JNIEnv.Handle, IntPtr.Zero, encCfgObj, value);
        }

        public void setRCTargetBitrate(int value)
        {
            Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCTargetBitrate(JNIEnv.Handle, IntPtr.Zero, encCfgObj, value);
        }

        public void setRCMinQuantizer(int value)
        {
            Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCMinQuantizer(JNIEnv.Handle, IntPtr.Zero, encCfgObj, value);
        }

        public void setRCMaxQuantizer(int value)
        {
            Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCMaxQuantizer(JNIEnv.Handle, IntPtr.Zero, encCfgObj, value);
        }

        public void setRCUndershootPct(int value)
        {
            Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCUndershootPct(JNIEnv.Handle, IntPtr.Zero, encCfgObj, value);
        }

        public void setRCOvershootPct(int value)
        {
            Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCOvershootPct(JNIEnv.Handle, IntPtr.Zero, encCfgObj, value);
        }

        public void setRCBufSz(int value)
        {
            Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCBufSz(JNIEnv.Handle, IntPtr.Zero, encCfgObj, value);
        }

        public void setRCBufInitialSz(int value)
        {
            Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCBufInitialSz(JNIEnv.Handle, IntPtr.Zero, encCfgObj, value);
        }

        public void setRCBufOptimalSz(int value)
        {
            Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetRCBufOptimalSz(JNIEnv.Handle, IntPtr.Zero, encCfgObj, value);
        }

        public void setKFMinDist(int value)
        {
            Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetKFMinDist(JNIEnv.Handle, IntPtr.Zero, encCfgObj, value);
        }

        public void setKFMaxDist(int value)
        {
            Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncSetKFMaxDist(JNIEnv.Handle, IntPtr.Zero, encCfgObj, value);
        }

        public int getThreads()
        {
            return Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetThreads(JNIEnv.Handle, IntPtr.Zero, encCfgObj);
        }

        public int getProfile()
        {
            return Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetProfile(JNIEnv.Handle, IntPtr.Zero, encCfgObj);
        }

        public int getWidth()
        {
            return Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetWidth(JNIEnv.Handle, IntPtr.Zero, encCfgObj);
        }

        public int getHeight()
        {
            return Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetHeight(JNIEnv.Handle, IntPtr.Zero, encCfgObj);
        }

        public Rational getTimebase()
        {
            return Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetTimebase(JNIEnv.Handle, IntPtr.Zero, encCfgObj);
        }

        public int getErrorResilient()
        {
            return Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetErrorResilient(JNIEnv.Handle, IntPtr.Zero, encCfgObj);
        }

        public int getPass()
        {
            return Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetPass(JNIEnv.Handle, IntPtr.Zero, encCfgObj);
        }

        public int getLagInFrames()
        {
            return Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetLagInFrames(JNIEnv.Handle, IntPtr.Zero, encCfgObj);
        }

        public int getRCDropframeThresh()
        {
            return Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCDropframeThresh(JNIEnv.Handle, IntPtr.Zero, encCfgObj);
        }

        public int getRCResizeAllowed()
        {
            return Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCResizeAllowed(JNIEnv.Handle, IntPtr.Zero, encCfgObj);
        }

        public int getRCResizeUpThresh()
        {
            return Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCResizeUpThresh(JNIEnv.Handle, IntPtr.Zero, encCfgObj);
        }

        public int getRCResizeDownThresh()
        {
            return Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCResizeDownThresh(JNIEnv.Handle, IntPtr.Zero, encCfgObj);
        }

        public int getRCEndUsage()
        {
            return Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCEndUsage(JNIEnv.Handle, IntPtr.Zero, encCfgObj);
        }

        public int getRCTargetBitrate()
        {
            return Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCTargetBitrate(JNIEnv.Handle, IntPtr.Zero, encCfgObj);
        }

        public int getRCMinQuantizer()
        {
            return Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCMinQuantizer(JNIEnv.Handle, IntPtr.Zero, encCfgObj);
        }

        public int getRCMaxQuantizer()
        {
            return Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCMaxQuantizer(JNIEnv.Handle, IntPtr.Zero, encCfgObj);
        }

        public int getRCUndershootPct()
        {
            return Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCUndershootPct(JNIEnv.Handle, IntPtr.Zero, encCfgObj);
        }

        public int getRCOvershootPct()
        {
            return Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCOvershootPct(JNIEnv.Handle, IntPtr.Zero, encCfgObj);
        }

        public int getRCBufSz()
        {
            return Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCBufSz(JNIEnv.Handle, IntPtr.Zero, encCfgObj);
        }

        public int getRCBufInitialSz()
        {
            return Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCBufInitialSz(JNIEnv.Handle, IntPtr.Zero, encCfgObj);
        }

        public int getRCBufOptimalSz()
        {
            return Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetRCBufOptimalSz(JNIEnv.Handle, IntPtr.Zero, encCfgObj);
        }

        public int getFourcc()
        {
            return Java_com_google_libvpx_LibVpxEncConfig_vpxCodecEncGetFourcc(JNIEnv.Handle, IntPtr.Zero);
        }
    }
}