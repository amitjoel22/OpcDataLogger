using System.Xml.Linq;

namespace OpcDataLogger.Interfaces
{
    public interface ISensorFactory
    {
        ISensor CreateInstance(XElement xElement);
    }
}
