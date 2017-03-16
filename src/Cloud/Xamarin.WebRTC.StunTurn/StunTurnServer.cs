using FM.IceLink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.WebRTC.StunTurn
{    /// <summary>
     /// Server class for handling STUN and TURN connections.
     /// </summary>
    public class StunTurnServer
    {
        private const string STUN_TURN_USERNAME = "3ecc90f264324bd28011db5d5d7daf4d";
        private const string STUN_TURN_PASSWORD = "c9a76b043c5c4577aa4605795717a40a";
        public void Start()
        {
            var server = new Server();
            
            server.EnableRelay((e) =>
            {
                if (e.Username == STUN_TURN_USERNAME)
                {
                    return RelayAuthenticateResult.FromLongTermKeyBytes(STUN.CreateLongTermKey(e.Username, e.Realm, STUN_TURN_PASSWORD));
                }
                return null;
            });
            server.Start();
        }
    }
}
