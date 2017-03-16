using System;
using System.Runtime.InteropServices;

using Android.Runtime;

using Java.Interop;

namespace Xamarin.WebRTC.Mobile.Android.Codecs.VP8
{
    class LibVpxEnc : LibVpxCom
    {
        // Enums from libyuv.
        public const long FOURCC_I420 = 0x30323449;
        public const long FOURCC_I422 = 0x32323449;
        public const long FOURCC_NV21 = 0x3132564E;
        public const long FOURCC_NV12 = 0x3231564E;
        public const long FOURCC_YUY2 = 0x32595559;
        public const long FOURCC_UYVY = 0x56595559;
        public const long FOURCC_ARGB = 0x42475241;
        public const long FOURCC_BGRA = 0x41524742;
        public const long FOURCC_ABGR = 0x52474241;
        public const long FOURCC_24BG = 0x47423432;  // rgb888
        public const long FOURCC_RGBA = 0x41424752;
        public const long FOURCC_RGBP = 0x50424752;  // bgr565.
        public const long FOURCC_RGBO = 0x4F424752;  // abgr1555.
        public const long FOURCC_R444 = 0x34343452;  // argb4444.
        public const long FOURCC_YV12 = 0x32315659;
        public const long FOURCC_YV16 = 0x36315659;

        [DllImport(LibVpxCom.DllPath)]
        private static extern void Java_com_google_libvpx_LibVpxEnc_vpxCodecEncInit(IntPtr env, IntPtr jniClass, long encoder, long cfg);

        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEnc_vpxCodecEncCtlSetCpuUsed(IntPtr env, IntPtr jniClass, long ctx, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEnc_vpxCodecEncCtlSetEnableAutoAltRef(IntPtr env, IntPtr jniClass, long ctx, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEnc_vpxCodecEncCtlSetNoiseSensitivity(IntPtr env, IntPtr jniClass, long ctx, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEnc_vpxCodecEncCtlSetSharpness(IntPtr env, IntPtr jniClass, long ctx, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEnc_vpxCodecEncCtlSetStaticThreshold(IntPtr env, IntPtr jniClass, long ctx, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEnc_vpxCodecEncCtlSetTokenPartitions(IntPtr env, IntPtr jniClass, long ctx, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEnc_vpxCodecEncCtlSetARNRMaxFrames(IntPtr env, IntPtr jniClass, long ctx, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEnc_vpxCodecEncCtlSetARNRStrength(IntPtr env, IntPtr jniClass, long ctx, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEnc_vpxCodecEncCtlSetARNRType(IntPtr env, IntPtr jniClass, long ctx, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEnc_vpxCodecEncCtlSetTuning(IntPtr env, IntPtr jniClass, long ctx, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEnc_vpxCodecEncCtlSetCQLevel(IntPtr env, IntPtr jniClass, long ctx, int value);
        [DllImport(LibVpxCom.DllPath)]
        private static extern int Java_com_google_libvpx_LibVpxEnc_vpxCodecEncCtlSetMaxIntraBitratePct(IntPtr env, IntPtr jniClass, long ctx, int value);

        [DllImport(LibVpxCom.DllPath)]
        private static extern bool Java_com_google_libvpx_LibVpxEnc_vpxCodecEncode(IntPtr env, IntPtr jniClass, long ctx, IntPtr frame, int fmt, long pts, long duration, long flags, long deadline);
        [DllImport(LibVpxCom.DllPath)]
        private static extern bool Java_com_google_libvpx_LibVpxEnc_vpxCodecConvertByteEncode(IntPtr env, IntPtr jniClass, long ctx, IntPtr frame, long pts, long duration, long flags, long deadline, long fourcc, int size, int rotation);
        [DllImport(LibVpxCom.DllPath)]
        private static extern bool Java_com_google_libvpx_LibVpxEnc_vpxCodecConvertIntEncode(IntPtr env, IntPtr jniClass, long ctx, IntPtr frame, long pts, long duration, long flags, long deadline, long fourcc, int size, int rotation);
        [DllImport(LibVpxCom.DllPath)]
        private static extern bool Java_com_google_libvpx_LibVpxEnc_vpxCodecHaveLibyuv(IntPtr env, IntPtr jniClass);

        [DllImport(LibVpxCom.DllPath)]
        private static extern IntPtr Java_com_google_libvpx_LibVpxEnc_vpxCodecEncGetCxData(IntPtr env, IntPtr jniClass, long ctx);

        // Enums from libvpx.
        public const int VPX_IMG_FMT_YV12 = 0x301;
        public const int VPX_IMG_FMT_I420 = 0x102;

        public LibVpxEnc(LibVpxEncConfig cfg)
        {
            vpxCodecIface = Java_com_google_libvpx_LibVpxCom_vpxCodecAllocCodec(JNIEnv.Handle, IntPtr.Zero);
            if (vpxCodecIface == 0)
            {
                throw new LibVpxException("Can not allocate JNI codec object");
            }

            Java_com_google_libvpx_LibVpxEnc_vpxCodecEncInit(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface, cfg.handle());
            if (isError())
            {
                String errorMsg = errorDetailString();
                Java_com_google_libvpx_LibVpxCom_vpxCodecFreeCodec(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface);
                throw new LibVpxException(errorMsg);
            }
        }

        public bool isError()
        {
            return Java_com_google_libvpx_LibVpxCom_vpxCodecIsError(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface);
        }

        private void throwOnError()
        {
            if (Java_com_google_libvpx_LibVpxCom_vpxCodecIsError(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface))
            {
                throw new LibVpxException(errorDetailString());
            }
        }

        public byte[] encodeFrame(
            byte[] frame, int fmt, long frameStart, long frameDuration, long flags, long deadline)
        {
            IntPtr framePtr = JNIEnv.NewArray(frame);
            try
            {
                if (!Java_com_google_libvpx_LibVpxEnc_vpxCodecEncode(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface,
                    framePtr, fmt, frameStart, frameDuration, flags, deadline))
                {
                    throw new LibVpxException("Unable to encode frame");
                }
                throwOnError();
                var result = Java_com_google_libvpx_LibVpxEnc_vpxCodecEncGetCxData(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface);
                JniEnvironment.References.CreatedReference(new JniObjectReference(result, JniObjectReferenceType.Local));
                return (byte[])JNIEnv.GetArray(result, JniHandleOwnership.TransferLocalRef, typeof(byte));
            }
            finally
            {
                JNIEnv.DeleteLocalRef(framePtr);
            }
        }

        public byte[] convertByteEncodeFrame(
            byte[] frame, long frameStart, long frameDuration, long flags, long deadline, long fourcc, int rotation)
        {
            IntPtr framePtr = JNIEnv.NewArray(frame);
            try
            {
                if (!Java_com_google_libvpx_LibVpxEnc_vpxCodecConvertByteEncode(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface,
                    framePtr, frameStart, frameDuration, flags, deadline, fourcc, frame.Length, rotation))
                {
                    throw new LibVpxException("Unable to convert and encode frame");
                }
                throwOnError();
                var result = Java_com_google_libvpx_LibVpxEnc_vpxCodecEncGetCxData(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface);
                JniEnvironment.References.CreatedReference(new JniObjectReference(result, JniObjectReferenceType.Local));
                return (byte[])JNIEnv.GetArray(result, JniHandleOwnership.TransferLocalRef, typeof(byte));
            }
            finally
            {
                JNIEnv.DeleteLocalRef(framePtr);
            }
        }

        public byte[] convertIntEncodeFrame(
            int[] frame, long frameStart, long frameDuration, long flags, long deadline, long fourcc, int rotation)
        {
            IntPtr framePtr = JNIEnv.NewArray(frame);
            try
            {
                if (!Java_com_google_libvpx_LibVpxEnc_vpxCodecConvertIntEncode(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface,
                    framePtr, frameStart, frameDuration, flags, deadline, fourcc, frame.Length, rotation))
                {
                    throw new LibVpxException("Unable to convert and encode frame");
                }
                throwOnError();
                var result = Java_com_google_libvpx_LibVpxEnc_vpxCodecEncGetCxData(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface);
                JniEnvironment.References.CreatedReference(new JniObjectReference(result, JniObjectReferenceType.Local));
                return (byte[])JNIEnv.GetArray(result, JniHandleOwnership.TransferLocalRef, typeof(byte));
            }
            finally
            {
                JNIEnv.DeleteLocalRef(framePtr);
            }
        }

        public static bool haveLibyuv()
        {
            return Java_com_google_libvpx_LibVpxEnc_vpxCodecHaveLibyuv(JNIEnv.Handle, IntPtr.Zero);
        }

        public void close()
        {
            Java_com_google_libvpx_LibVpxCom_vpxCodecDestroy(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface);
            Java_com_google_libvpx_LibVpxCom_vpxCodecFreeCodec(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface);
        }

        public void setCpuUsed(int value)
        {
            // TODO(frkoenig) : Investigate anonymous interface class to reduce duplication
            if (Java_com_google_libvpx_LibVpxEnc_vpxCodecEncCtlSetCpuUsed(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface, value) != 0)
            {
                throw new LibVpxException("Unable to set CpuUsed");
            }

            throwOnError();
        }

        public void setEnableAutoAltRef(int value)
        {
            if (Java_com_google_libvpx_LibVpxEnc_vpxCodecEncCtlSetEnableAutoAltRef(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface, value) != 0)
            {
                throw new LibVpxException("Unable to Enable Auto Alt Ref");
            }

            throwOnError();
        }

        public void setNoiseSensitivity(int value)
        {
            if (Java_com_google_libvpx_LibVpxEnc_vpxCodecEncCtlSetNoiseSensitivity(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface, value) != 0)
            {
                throw new LibVpxException("Unable to set Noise Sensitivity");
            }

            throwOnError();
        }

        public void setSharpness(int value)
        {
            if (Java_com_google_libvpx_LibVpxEnc_vpxCodecEncCtlSetSharpness(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface, value) != 0)
            {
                throw new LibVpxException("Unable to set Sharpness");
            }

            throwOnError();
        }

        public void setStaticThreshold(int value)
        {
            if (Java_com_google_libvpx_LibVpxEnc_vpxCodecEncCtlSetStaticThreshold(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface, value) != 0)
            {
                throw new LibVpxException("Unable to set Static Threshold");
            }

            throwOnError();
        }

        public void setTokenPartitions(int value)
        {
            if (Java_com_google_libvpx_LibVpxEnc_vpxCodecEncCtlSetTokenPartitions(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface, value) != 0)
            {
                throw new LibVpxException("Unable to set Token Partitions");
            }

            throwOnError();
        }

        public void setARNRMaxFrames(int value)
        {
            if (Java_com_google_libvpx_LibVpxEnc_vpxCodecEncCtlSetARNRMaxFrames(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface, value) != 0)
            {
                throw new LibVpxException("Unable to set ARNR Max Frames");
            }

            throwOnError();
        }

        public void setARNRStrength(int value)
        {
            if (Java_com_google_libvpx_LibVpxEnc_vpxCodecEncCtlSetARNRStrength(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface, value) != 0)
            {
                throw new LibVpxException("Unable to set ARNR Strength");
            }

            throwOnError();
        }

        public void setARNRType(int value)
        {
            if (Java_com_google_libvpx_LibVpxEnc_vpxCodecEncCtlSetARNRType(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface, value) != 0)
            {
                throw new LibVpxException("Unable to set ARNRType");
            }

            throwOnError();
        }

        public void setTuning(int value)
        {
            if (Java_com_google_libvpx_LibVpxEnc_vpxCodecEncCtlSetTuning(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface, value) != 0)
            {
                throw new LibVpxException("Unable to set Tuning");
            }

            throwOnError();
        }

        public void setCQLevel(int value)
        {
            if (Java_com_google_libvpx_LibVpxEnc_vpxCodecEncCtlSetCQLevel(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface, value) != 0)
            {
                throw new LibVpxException("Unable to set CQLevel");
            }

            throwOnError();
        }

        public void setMaxIntraBitratePct(int value)
        {
            if (Java_com_google_libvpx_LibVpxEnc_vpxCodecEncCtlSetMaxIntraBitratePct(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface, value) != 0)
            {
                throw new LibVpxException("Unable to set Max Intra Bitrate Pct");
            }

            throwOnError();
        }
    }
}