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
    }
}