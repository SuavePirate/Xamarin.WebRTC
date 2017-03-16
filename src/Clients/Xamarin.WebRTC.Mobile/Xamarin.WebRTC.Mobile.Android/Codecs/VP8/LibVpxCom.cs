using System;
using System.Runtime.InteropServices;
using FM;

using Android.Runtime;

using Java.Interop;

namespace Xamarin.WebRTC.Mobile.Android.Codecs.VP8
{
    class LibVpxCom
    {
        public const string DllPath = "libvpxJNI.so";

        protected long vpxCodecIface;

        [DllImport(LibVpxCom.DllPath)]
        protected static extern IntPtr Java_com_google_libvpx_LibVpxCom_vpxCodecVersionStr(IntPtr env, IntPtr jniClass);
        [DllImport(LibVpxCom.DllPath)]
        protected static extern IntPtr Java_com_google_libvpx_LibVpxCom_vpxCodecVersionExtraStr(IntPtr env, IntPtr jniClass);
        [DllImport(LibVpxCom.DllPath)]
        protected static extern IntPtr Java_com_google_libvpx_LibVpxCom_vpxCodecBuildConfig(IntPtr env, IntPtr jniClass);

        [DllImport(LibVpxCom.DllPath)]
        protected static extern bool Java_com_google_libvpx_LibVpxCom_vpxCodecIsError(IntPtr env, IntPtr jniClass, long ctx);
        [DllImport(LibVpxCom.DllPath)]
        protected static extern IntPtr Java_com_google_libvpx_LibVpxCom_vpxCodecErrToString(IntPtr env, IntPtr jniClass, int err);
        [DllImport(LibVpxCom.DllPath)]
        protected static extern IntPtr Java_com_google_libvpx_LibVpxCom_vpxCodecError(IntPtr env, IntPtr jniClass, long ctx);
        [DllImport(LibVpxCom.DllPath)]
        protected static extern IntPtr Java_com_google_libvpx_LibVpxCom_vpxCodecErrorDetail(IntPtr env, IntPtr jniClass, long ctx);

        [DllImport(LibVpxCom.DllPath)]
        protected static extern long Java_com_google_libvpx_LibVpxCom_vpxCodecAllocCodec(IntPtr env, IntPtr jniClass);
        [DllImport(LibVpxCom.DllPath)]
        protected static extern void Java_com_google_libvpx_LibVpxCom_vpxCodecFreeCodec(IntPtr env, IntPtr jniClass, long cfg);

        [DllImport(LibVpxCom.DllPath)]
        protected static extern void Java_com_google_libvpx_LibVpxCom_vpxCodecDestroy(IntPtr env, IntPtr jniClass, long ctx);

        public string versionString()
        {
            var result = Java_com_google_libvpx_LibVpxCom_vpxCodecVersionStr(JNIEnv.Handle, IntPtr.Zero);
            JniEnvironment.References.CreatedReference(new JniObjectReference(result, JniObjectReferenceType.Local));
            return Java.Lang.Object.GetObject<Java.Lang.String>(result, JniHandleOwnership.TransferLocalRef).ToString();
        }

        public string versionExtraString()
        {
            var result = Java_com_google_libvpx_LibVpxCom_vpxCodecVersionExtraStr(JNIEnv.Handle, IntPtr.Zero);
            JniEnvironment.References.CreatedReference(new JniObjectReference(result, JniObjectReferenceType.Local));
            return Java.Lang.Object.GetObject<Java.Lang.String>(result, JniHandleOwnership.TransferLocalRef).ToString();
        }

        public string buildConfigString()
        {
            var result = Java_com_google_libvpx_LibVpxCom_vpxCodecBuildConfig(JNIEnv.Handle, IntPtr.Zero);
            JniEnvironment.References.CreatedReference(new JniObjectReference(result, JniObjectReferenceType.Local));
            return Java.Lang.Object.GetObject<Java.Lang.String>(result, JniHandleOwnership.TransferLocalRef).ToString();
        }

        public string errToString(int err)
        {
            var result = Java_com_google_libvpx_LibVpxCom_vpxCodecErrToString(JNIEnv.Handle, IntPtr.Zero, err);
            JniEnvironment.References.CreatedReference(new JniObjectReference(result, JniObjectReferenceType.Local));
            return Java.Lang.Object.GetObject<Java.Lang.String>(result, JniHandleOwnership.TransferLocalRef).ToString();
        }

        public string errorString()
        {
            var result = Java_com_google_libvpx_LibVpxCom_vpxCodecError(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface);
            JniEnvironment.References.CreatedReference(new JniObjectReference(result, JniObjectReferenceType.Local));
            return Java.Lang.Object.GetObject<Java.Lang.String>(result, JniHandleOwnership.TransferLocalRef).ToString();
        }

        public string errorDetailString()
        {
            var result = Java_com_google_libvpx_LibVpxCom_vpxCodecErrorDetail(JNIEnv.Handle, IntPtr.Zero, vpxCodecIface);
            JniEnvironment.References.CreatedReference(new JniObjectReference(result, JniObjectReferenceType.Local));
            return Java.Lang.Object.GetObject<Java.Lang.String>(result, JniHandleOwnership.TransferLocalRef).ToString();
        }
    }
}