using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.WebRTC.Mobile
{
    public class CandidateEventArgs : EventArgs
    {
        public string PeerId { get; set; }
        public string Json { get; set; }
    }
}
