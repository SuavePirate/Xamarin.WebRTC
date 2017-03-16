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

namespace Xamarin.WebRTC.Mobile.Droid
{
    [Activity]
    public class ConferenceActivity : Activity
    {
        private readonly ConferenceService _conferenceService;
        public ConferenceActivity()
        {
            _conferenceService = new ConferenceService();
        }

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Call);
            var audioButton = FindViewById<Button>(Resource.Id.muteAudioButton);
            var videoButton = FindViewById<Button>(Resource.Id.muteVideoButton);

            await _conferenceService.StartAsync("hodor", FindViewById<RelativeLayout>(Resource.Id.videoContainer));
            audioButton.Click += (s, a) =>
            {
                _conferenceService.ToggleMute();
            };
            videoButton.Click += (s, a) =>
            {
                _conferenceService.ToggleMuteVideo();
            };

        }
    }
}