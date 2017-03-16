using System;
using System.Runtime.InteropServices;

using Android.Runtime;

namespace Xamarin.WebRTC.Mobile.Android.Codecs.VP8
{
    class LibVpxException : Exception
    {
        public LibVpxException(string msg)
            : base(msg)
        { }
    }
}