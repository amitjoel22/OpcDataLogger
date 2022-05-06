using Kepware.ClientAce.OpcDaClient;
using OpcDataLogger.Models.EventArgs;
using System;

namespace OpcDataLogger.Interfaces
{
    public interface IServer
    {
        event EventHandler<ServerDataChangedEventArgs> DataChanged;
        event EventHandler<ServerStateChangedEventArgs> ServerStateChanged;

        bool Connect(string url, int clientHandle, bool retryInitialConnection, bool retryAfterConnectionError, int keepAliveTime);
        void Disconnect();
        void Dispose();
        void Subscribe(int clientSubscription, bool active, int updateRate, ref ItemIdentifier[] items, out int revisedUdpateRate, out int serverSubscription);
        void SubscriptionModify(int clientSubscription, bool active);
    }
}