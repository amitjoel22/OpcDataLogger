using Kepware.ClientAce.OpcDaClient;
using OpcDataLogger.Interfaces;
using OpcDataLogger.Models.EventArgs;
using System;

namespace OpcDataLogger.Models
{
    public class Server : IServer
    {
        public event EventHandler<ServerDataChangedEventArgs> DataChanged;
        public event EventHandler<ServerStateChangedEventArgs> ServerStateChanged;

        private readonly DaServerMgt _aceServer;

        public Server()
        {
            _aceServer = new DaServerMgt();
            _aceServer.DataChanged += AceServer_DataChanged;
            _aceServer.ServerStateChanged += AceServer_ServerStateChanged;
        }

        private void AceServer_ServerStateChanged(int clientHandle, ServerState state) =>
            ServerStateChanged?.Invoke(this, new ServerStateChangedEventArgs(clientHandle, state));

        private void AceServer_DataChanged(int clientSubscription, bool allQualitiesGood, bool noErrors, ItemValueCallback[] itemValues) =>
            DataChanged?.Invoke(this, new ServerDataChangedEventArgs(clientSubscription, allQualitiesGood, noErrors, itemValues));

        public bool Connect(string url, int clientHandle, bool retryInitialConnection, bool retryAfterConnectionError, int keepAliveTime)
        {
            var connInfo = new ConnectInfo("en", retryInitialConnection, retryAfterConnectionError, keepAliveTime);
            _aceServer.Connect(url, clientHandle, ref connInfo, out bool isConnectionFailed);
            return !isConnectionFailed;
        }

        public void Disconnect()
        {
            if (_aceServer.IsConnected)
            {
                _aceServer.Disconnect();
            }
        }

        public void Dispose() =>
            _aceServer?.Dispose();

        public void Subscribe(int clientSubscription, bool active, int updateRate, ref ItemIdentifier[] items, out int revisedUdpateRate, out int serverSubscription)
        {
            revisedUdpateRate = -1;
            serverSubscription = -1;
            _aceServer?.Subscribe(clientSubscription, active, updateRate, out revisedUdpateRate, 0f, ref items, out serverSubscription);
        }

        public void SubscriptionModify(int serverSubscription, bool active) =>
            _aceServer?.SubscriptionModify(serverSubscription, active);
    }
}
