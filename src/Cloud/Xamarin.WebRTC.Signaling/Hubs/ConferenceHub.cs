using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xamarin.WebRTC.Signaling.Hubs
{
    public class ConferenceHub : Hub
    {
        public void JoinRoom(string roomName)
        {
            Clients.Group(roomName).newConnection(Context.ConnectionId);
            Groups.Add(Context.ConnectionId, roomName);
        }
        public void SendOfferAnswer(string peerId, string json)
        {
            Clients.Client(peerId).receiveOfferAnswer(Context.ConnectionId, json);
        }

        public void SendCandidate(string peerId, string json)
        {
            Clients.Client(peerId).receiveCandidate(Context.ConnectionId, json);
        }
    }
}