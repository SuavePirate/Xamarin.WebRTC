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
        private const string CONNECTION_URL = "http://xamarinwebrtcsignalingexample.azurewebsites.net/";
        private readonly HubConnection _connection;
        private readonly IHubProxy _conferenceHubProxy;
        public event EventHandler<PeerConnectionEventArgs> OnNewConnection;
        public event EventHandler<OfferAnswerEventArgs> OnNewOfferAnswer;
        public event EventHandler<CandidateEventArgs> OnNewCandidate;
        // Set these externally
     
        public SignalingService()
        {
            _connection = new HubConnection(CONNECTION_URL);
            _conferenceHubProxy = _connection.CreateHubProxy("ConferenceHub");
            InitEndpoints();
        }

        public async Task StartAsync()
        {
            await _connection.Start();
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
            _conferenceHubProxy.On<string>("newConnection", (peerId) =>
            {
                OnNewConnection?.Invoke(this, new PeerConnectionEventArgs
                {
                    PeerId = peerId
                });
            });

            _conferenceHubProxy.On<string,string>("receiveOfferAnswer", (peerId, json) =>
            {
                OnNewOfferAnswer?.Invoke(this, new OfferAnswerEventArgs
                {
                    PeerId = peerId,
                    Json = json
                });
            });

            _conferenceHubProxy.On<string,string>("receiveCandidate", (peerId, json) =>
            {
                OnNewCandidate?.Invoke(this, new CandidateEventArgs
                {
                    PeerId = peerId,
                    Json = json
                });
            });
        }
    }
}
