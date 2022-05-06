using System.Xml.Linq;

namespace OpcDataLogger.Interfaces
{
    public interface IConditionFactory
    {
        ICondition CreateInstance(XElement xElement);
    }
}
