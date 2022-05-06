using Kepware.ClientAce.OpcDaClient;
using OpcDataLogger.Interfaces;

namespace OpcDataLogger.Models.Conditions
{
    public class AlwaysPassCondition : ICondition
    {
        public bool Check(ItemValueCallback oldItemValue, ItemValueCallback newItemValue) =>
            true;
    }
}
