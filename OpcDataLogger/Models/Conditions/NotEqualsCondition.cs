using Kepware.ClientAce.OpcDaClient;
using OpcDataLogger.Interfaces;

namespace OpcDataLogger.Models.Conditions
{
    public class NotEqualsCondition : ICondition
    {
        public bool Check(ItemValueCallback oldItemValue, ItemValueCallback newItemValue) =>
            null == oldItemValue || !oldItemValue.Value.Equals(newItemValue.Value);
    }
}
