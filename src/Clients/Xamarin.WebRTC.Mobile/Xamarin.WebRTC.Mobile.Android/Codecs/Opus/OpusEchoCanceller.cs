using System;
using Android.OS;
using FM;
using FM.IceLink.WebRTC;

using Xamarin.WebRTC.Mobile.Android.Codecs.AudioProcessing;

namespace Xamarin.WebRTC.Mobile.Android.Codecs.Opus
{
	public class OpusEchoCanceller
    {
        private static bool x86 = false;
        private static bool arm64 = false;
        static OpusEchoCanceller()
        {
            if (Build.CpuAbi.ToLower().Contains("x86"))
            {
                x86 = true;
            }
            if (Build.CpuAbi.ToLower().Contains("arm64"))
            {
                arm64 = true;
            }
		}

		public static bool IsSupported
		{
			get { return !x86 && !arm64; }
		}

		private AcousticEchoCanceller AcousticEchoCanceller;
		private AudioMixer AudioMixer;

		public OpusEchoCanceller(int clockRate, int channels)
			: this(clockRate, channels, false)
		{ }

		public OpusEchoCanceller(int clockRate, int channels, bool useMixer)
		{
			if (IsSupported)
            {
                AcousticEchoCanceller = new AcousticEchoCanceller(clockRate, channels, 150);
				if (useMixer)
				{
					AudioMixer = new AudioMixer(clockRate, channels, 20);
					AudioMixer.OnFrame += OnAudioMixerFrame;
				}
            }
		}

		public void Start()
        {
			if (IsSupported && AudioMixer != null)
            {
                AudioMixer.Start();
            }
		}

		public void Stop()
        {
			if (IsSupported && AudioMixer != null)
            {
                AudioMixer.Stop();
            }
		}

		public byte[] capture(AudioBuffer input)
        {
			if (IsSupported)
            {
                return AcousticEchoCanceller.Capture(input.Data, input.Index, input.Length);
            }
            else
            {
                return BitAssistant.SubArray(input.Data, input.Index, input.Length);
            }
		}

		public void render(String peerId, AudioBuffer echo)
        {
			if (IsSupported)
            {
				if (AudioMixer != null)
				{
					AudioMixer.AddSourceFrame(peerId, new AudioBuffer(echo.Data, echo.Index, echo.Length));
				}
				else
				{
					AcousticEchoCanceller.Render(echo.Data, echo.Index, echo.Length);
				}
            }
		}

		private void OnAudioMixerFrame(AudioBuffer echoMixed)
        {
			if (IsSupported)
            {
                AcousticEchoCanceller.Render(echoMixed.Data, echoMixed.Index, echoMixed.Length);
            }
		}
	}
}

