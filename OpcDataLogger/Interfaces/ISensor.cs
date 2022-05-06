using Kepware.ClientAce.OpcDaClient;
using OpcDataLogger.Models.EventArgs;
using System;

namespace OpcDataLogger.Interfaces
{
    public interface ISensor
    {
        event EventHandler<SensorDataChangedEventArgs> DataChanged;

        ItemIdentifier ItemIdentifier { get; }

        void DataChange(ItemValueCallback currentValue);
    }
}