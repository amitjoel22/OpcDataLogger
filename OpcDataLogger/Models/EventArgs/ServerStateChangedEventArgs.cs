using Kepware.ClientAce.OpcDaClient;

namespace OpcDataLogger.Models.EventArgs
{
    public class ServerStateChangedEventArgs : System.EventArgs
    {
        public int ClientHandle { get; }
        public ServerState State { get; }

        public ServerStateChangedEventArgs(int clientHandle, ServerState state) =>
            (ClientHandle, State) = (clientHandle, state);
    }
}
