using Kepware.ClientAce.OpcDaClient;
using System.Xml.Linq;

namespace OpcDataLogger.Interfaces
{
    public interface IItemIdentifierFactory
    {
        ItemIdentifier CreateInstance(XElement xElement);
    }
}
