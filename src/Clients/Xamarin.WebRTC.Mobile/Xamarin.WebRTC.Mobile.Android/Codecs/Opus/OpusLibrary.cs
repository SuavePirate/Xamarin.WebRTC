using System;
using System.Runtime.InteropServices;

namespace Xamarin.WebRTC.Mobile.Android.Codecs.Opus
{
    public class OpusLibrary
    {
        public const string DllPath = "libopusJNI.so";

        [DllImport(OpusLibrary.DllPath)]
        public static extern int Java_aopus_OpusLibrary_encoderGetBitrate(IntPtr env, IntPtr jniClass, long state);
        [DllImport(OpusLibrary.DllPath)]
        public static extern void Java_aopus_OpusLibrary_encoderSetBitrate(IntPtr env, IntPtr jniClass, long state, int value);
        [DllImport(OpusLibrary.DllPath)]
        public static extern double Java_aopus_OpusLibrary_encoderGetQuality(IntPtr env, IntPtr jniClass, long state);
        [DllImport(OpusLibrary.DllPath)]
        public static extern void Java_aopus_OpusLibrary_encoderSetQuality(IntPtr env, IntPtr jniClass, long state, double value);
        [DllImport(OpusLibrary.DllPath)]
        public static extern long Java_aopus_OpusLibrary_encoderCreate(IntPtr env, IntPtr jniClass, int clockRate, int channels, int packetTime);
        [DllImport(OpusLibrary.DllPath)]
        public static extern void Java_aopus_OpusLibrary_encoderActivateFEC(IntPtr env, IntPtr jniClass, long state, int packetLossPercent);
        [DllImport(OpusLibrary.DllPath)]
        public static extern void Java_aopus_OpusLibrary_encoderDeactivateFEC(IntPtr env, IntPtr jniClass, long state);
        [DllImport(OpusLibrary.DllPath)]
        public static extern void Java_aopus_OpusLibrary_encoderDestroy(IntPtr env, IntPtr jniClass, long state);
        [DllImport(OpusLibrary.DllPath)]
        public static extern IntPtr Java_aopus_OpusLibrary_encoderEncode(IntPtr env, IntPtr jniClass, long state, IntPtr data, int index, int length);

        [DllImport(OpusLibrary.DllPath)]
        public static extern long Java_aopus_OpusLibrary_decoderCreate(IntPtr env, IntPtr jniClass, int clockRate, int channels, int packetTime);
        [DllImport(OpusLibrary.DllPath)]
        public static extern void Java_aopus_OpusLibrary_decoderDestroy(IntPtr env, IntPtr jniClass, long state);
        [DllImport(OpusLibrary.DllPath)]
        public static extern IntPtr Java_aopus_OpusLibrary_decoderDecode(IntPtr env, IntPtr jniClass, long state, IntPtr encodedData);
        [DllImport(OpusLibrary.DllPath)]
        public static extern IntPtr Java_aopus_OpusLibrary_decoderDecode2(IntPtr env, IntPtr jniClass, long state, IntPtr encodedData, bool fec);
    }
}