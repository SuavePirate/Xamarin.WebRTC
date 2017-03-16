using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.WebRTC.Mobile
{
    /// <summary>
    /// Service class for communicating to the Signaling Server
    /// </summary>
    public class SignalingService
    {
        private const string CONNECTION_URL = "{PUT YOUR URL FOR SIGNALR HERE}";
        private readonly HubConnection _connection;
        private readonly IHubProxy _conferenceHubProxy;

        // Set these externally
        public Action<string> NewConnectionAction { private get; set; }
        public Action<string,string> ReceiveOfferAnswerAction { private get; set; }
        public Action<string,string> ReceiveCandidateAction { private get; set; }


        public SignalingService()
        {
            _connection = new HubConnection(CONNECTION_URL);
            _conferenceHubProxy = _connection.CreateHubProxy("ConferenceHub");
            InitEndpoints();
        }

        public async Task JoinConferenceAsync(string conferenceName)
        {
            await _conferenceHubProxy.Invoke("JoinRoom", conferenceName);
        }

        public async Task SendOfferAnswer(string peerId, string json)
        {
            await _conferenceHubProxy.Invoke("SendOfferAnswer", peerId, json);
        }

        public async Task SendICECandidate(string peerId, string json)
        {
            await _conferenceHubProxy.Invoke("SendCandidate", peerId, json);
        }

        /// <summary>
        /// Initialize the endpoint listeners for the web socket
        /// </summary>
        private void InitEndpoints()
        {
            _conferenceHubProxy.On("newConnection", NewConnectionAction);

            _conferenceHubProxy.On("receiveOfferAnswer", ReceiveOfferAnswerAction);

            _conferenceHubProxy.On("receiveCandidate", ReceiveCandidateAction);
        }
    }
}
