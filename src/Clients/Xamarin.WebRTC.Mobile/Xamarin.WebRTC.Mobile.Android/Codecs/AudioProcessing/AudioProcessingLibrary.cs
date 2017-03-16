using System;
using System.Runtime.InteropServices;

namespace Xamarin.WebRTC.Mobile.Android.Codecs.AudioProcessing
{
	public class AudioProcessingLibrary
	{
		public const string DllPath = "libaudioprocessingJNI.so";

		[DllImport(AudioProcessingLibrary.DllPath)]
		public static extern long Java_aaudioprocessing_AudioProcessingLibrary_acousticEchoCancellerCreate(IntPtr env, IntPtr jniClass, int clockRate, int channels, int tailLength);
		[DllImport(AudioProcessingLibrary.DllPath)]
		public static extern void Java_aaudioprocessing_AudioProcessingLibrary_acousticEchoCancellerDestroy(IntPtr env, IntPtr jniClass, long state);
		[DllImport(AudioProcessingLibrary.DllPath)]
		public static extern void Java_aaudioprocessing_AudioProcessingLibrary_acousticEchoCancellerRender(IntPtr env, IntPtr jniClass, long state, IntPtr echoData, int echoIndex, int echoLength);
		[DllImport(AudioProcessingLibrary.DllPath)]
		public static extern IntPtr Java_aaudioprocessing_AudioProcessingLibrary_acousticEchoCancellerCapture(IntPtr env, IntPtr jniClass, long state, IntPtr inputData, int inputIndex, int inputLength);
	}
}