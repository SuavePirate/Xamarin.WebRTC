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
    [Activity (Label = "Conference")]
    public class ConferenceActivity : Activity
    {
        private ConferenceService _conferenceService;
        public ConferenceActivity()
        {
        }

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _conferenceService = new ConferenceService();
            SetContentView(Resource.Layout.Call);
            //var audioButton = FindViewById<Button>(Resource.Id.muteAudioButton);
            //var videoButton = FindViewById<Button>(Resource.Id.muteVideoButton);
            var videoContainer = FindViewById<RelativeLayout>(Resource.Id.videoContainer);
            await _conferenceService.StartAsync("hodor", videoContainer);
            //audioButton.Click += (s, a) =>
            //{
            //    _conferenceService.ToggleMute();
            //};
            //videoButton.Click += (s, a) =>
            //{
            //    _conferenceService.ToggleMuteVideo();
            //};

        }
    }
}