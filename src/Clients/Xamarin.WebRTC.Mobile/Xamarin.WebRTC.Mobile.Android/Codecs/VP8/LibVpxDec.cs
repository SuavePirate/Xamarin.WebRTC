using System;
using System.Runtime.InteropServices;

using Android.Runtime;

using Java.Interop;

namespace Xamarin.WebRTC.Mobile.Android.Codecs.VP8
{
    class LibVpxDec : LibVpxCom
    {
        private long decCfgObj;

        [DllImport(LibVpxCom.DllPath)]
        private static extern long Java_com_google_libvpx_LibVpxDec_vpxCodecDecAllocCfg(IntPtr env, IntPtr jniClass);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxDec_vpxCodecDecFreeCfg(IntPtr env, IntPtr jniClass, long cfg);

        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxDec_vpxCodecDecSetThreads(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxDec_vpxCodecDecSetWidth(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxDec_vpxCodecDecSetHeight(IntPtr env, IntPtr jniClass, long cfg, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxDec_vpxCodecDecGetThreads(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxDec_vpxCodecDecGetWidth(IntPtr env, IntPtr jniClass, long cfg);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxDec_vpxCodecDecGetHeight(IntPtr env, IntPtr jniClass, long cfg);

        [DllImport(LibVpxCom.DllPath)]
        private static extern bool Java_com_google_libvpx_LibVpxDec_vpxCodecDecInit(IntPtr env, IntPtr jniClass, long decoder, long cfg, bool postproc, bool ecEnabled);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxDec_vpxCodecDecDecode(IntPtr env, IntPtr jniClass, long decoder, IntPtr buf, int bufSize);
        [DllImport(LibVpxCom.DllPath)]
        private static extern IntPtr Java_com_google_libvpx_LibVpxDec_vpxCodecDecGetFrame(IntPtr env, IntPtr jniClass, long decoder, IntPtr widthHeight);

        public LibVpxDec(int width, int height, int threads, bool postProcEnabled, bool errorConcealmentEnabled)
        {
            decCfgObj = Java_com_google_libvpx_LibVpxDec_vpxCodecDecAllocCfg(JNIEnv.Handle, IntPtr.Zero);
            vpxCodecIface = Java_com_google_libvpx_LibVpxCom_vpxCodecAllocCodec(JNIEnv.Handle, IntPtr.Zero);

            if (width > 0)
            {
                Java_com_google_libvpx_LibVpxDec_vpxCodecDecSetWidth(JNIEnv.Handle, IntPtr.Zero, decCfgObj, width);
            }

            if (height > 0)
            {
                Java_com_google_libvpx_LibVpxDec_vpxCodecDecSetHeight(JNIEnv.Handle, IntPtr.Zero, decCfgObj, height);
            }

            if (threads > 0)
            {
                Java_com_google_libvpx_LibVpxDec_vpxCodecDecSetThreads(JNIEnv.Handle, IntPtr.Zero, decCfgObj, threads);
            }

            if (!Java_com_google_libvpx_LibVpxDec_vpxCodecDecInit(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface, decCfgObj,
                                 postProcEnabled, errorConcealmentEnabled))
            {
                throw new LibVpxException(errorString());
            }
        }

        public LibVpxDec(bool postProcEnabled,
            bool errorConcealmentEnabled)
            : this(0, 0, 0, postProcEnabled, errorConcealmentEnabled)
        { }

        public LibVpxDec()
            : this(0, 0, 0, false, false)
        { }

        public byte[] decodeFrameToBuffer(byte[] rawFrame, int[] widthHeight, int[] result)
        {
            var rawFramePtr = JNIEnv.NewArray(rawFrame);
            try
            {
                result[0] = Java_com_google_libvpx_LibVpxDec_vpxCodecDecDecode(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface, rawFramePtr, rawFrame.Length);
                if (result[0] == 5)
                {
                    return null;
                }
                if (result[0] != 0)
                {
                    throw new LibVpxException(errorDetailString());
                }

                var widthHeightPtr = JNIEnv.NewArray(widthHeight);
                try
                {
                    var output = Java_com_google_libvpx_LibVpxDec_vpxCodecDecGetFrame(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface, widthHeightPtr);
                    JniEnvironment.References.CreatedReference(new JniObjectReference(output, JniObjectReferenceType.Local));
                    byte[] decoded = (byte[])JNIEnv.GetArray(output, JniHandleOwnership.TransferLocalRef, typeof(byte));
                    widthHeight[0] = JNIEnv.GetArrayItem<int>(widthHeightPtr, 0);
                    widthHeight[1] = JNIEnv.GetArrayItem<int>(widthHeightPtr, 1);
                    return decoded;
                }
                finally
                {
                    JNIEnv.DeleteLocalRef(widthHeightPtr);
                }
            }
            finally
            {
                JNIEnv.DeleteLocalRef(rawFramePtr);
            }
        }

        public void close()
        {
            Java_com_google_libvpx_LibVpxCom_vpxCodecDestroy(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface);
            Java_com_google_libvpx_LibVpxDec_vpxCodecDecFreeCfg(JNIEnv.Handle, IntPtr.Zero, decCfgObj);
            Java_com_google_libvpx_LibVpxCom_vpxCodecFreeCodec(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface);
        }
    }
}