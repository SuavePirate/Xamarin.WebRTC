using System;

using Android.Media.Audiofx;
using Android.OS;
using Android.Runtime;

using FM.IceLink.WebRTC;

namespace Xamarin.WebRTC.Mobile.Android.Codecs.AudioProcessing
{
	public class AcousticEchoCanceller : IDisposable
	{
		private long State;

		public AcousticEchoCanceller(int clockRate, int channels, int tailLength)
		{
			State = AudioProcessingLibrary.Java_aaudioprocessing_AudioProcessingLibrary_acousticEchoCancellerCreate(JNIEnv.Handle, IntPtr.Zero, clockRate, channels, tailLength);
		}

		public void Dispose()
		{
			AudioProcessingLibrary.Java_aaudioprocessing_AudioProcessingLibrary_acousticEchoCancellerDestroy(JNIEnv.Handle, IntPtr.Zero, State);
		}

		public void Render(byte[] echoData, int echoIndex, int echoLength)
		{
			IntPtr echoDataPtr = JNIEnv.NewArray(echoData);
			try
			{
				AudioProcessingLibrary.Java_aaudioprocessing_AudioProcessingLibrary_acousticEchoCancellerRender(JNIEnv.Handle, IntPtr.Zero, State, echoDataPtr, echoIndex, echoLength);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(echoDataPtr);
			}
		}

		public byte[] Capture(byte[] inputData, int inputIndex, int inputLength)
		{
			IntPtr inputDataPtr = JNIEnv.NewArray(inputData);
			try
            {
                return (byte[])JNIEnv.GetArray(AudioProcessingLibrary.Java_aaudioprocessing_AudioProcessingLibrary_acousticEchoCancellerCapture(JNIEnv.Handle, IntPtr.Zero, State, inputDataPtr, inputIndex, inputLength), JniHandleOwnership.DoNotTransfer, typeof(byte));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(inputDataPtr);
			}
		}
	}
}