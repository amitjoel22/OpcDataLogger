using Kepware.ClientAce.OpcDaClient;

namespace OpcDataLogger.Models.EventArgs
{
    public class SensorDataChangedEventArgs : System.EventArgs
    {
        public ItemValueCallback ItemValue { get; }

        public SensorDataChangedEventArgs(ItemValueCallback itemValue) =>
            ItemValue = itemValue;
    }
}
