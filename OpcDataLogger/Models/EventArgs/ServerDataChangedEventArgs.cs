using Kepware.ClientAce.OpcDaClient;

namespace OpcDataLogger.Models.EventArgs
{
    public class ServerDataChangedEventArgs : System.EventArgs
    {
        public bool NoErrors { get; }
        public bool AllQualitiesGood { get; }
        public int ClientSubscription { get; }
        public ItemValueCallback[] ItemValues { get; }

        public ServerDataChangedEventArgs(int clientSubscription, bool allQualitiesGood, bool noErrors, ItemValueCallback[] itemValues) =>
            (ClientSubscription, AllQualitiesGood, NoErrors, ItemValues) = (clientSubscription, allQualitiesGood, noErrors, itemValues);
    }
}
