using System.Xml.Linq;

namespace OpcDataLogger.Interfaces
{
    public interface IRepo
    {
        XDocument GetXml();
    }
}
