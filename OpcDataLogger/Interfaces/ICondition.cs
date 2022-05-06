using Kepware.ClientAce.OpcDaClient;

namespace OpcDataLogger.Interfaces
{
    public interface ICondition
    {
        bool Check(ItemValueCallback oldItemValue, ItemValueCallback newItemValue);
    }
}
