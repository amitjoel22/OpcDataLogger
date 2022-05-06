using Kepware.ClientAce.OpcDaClient;
using OpcDataLogger.Interfaces;
using System;
using System.Xml.Linq;

namespace OpcDataLogger.Models.Factories
{
    public class ItemIdentifierFactory : IItemIdentifierFactory
    {
        private const string itemIdAttributeName = "OPC_Tag";
        private const string clientHandleAttributeName = "id_log";

        public ItemIdentifier CreateInstance(XElement xElement)
        {
            var itemId = xElement.Attribute(itemIdAttributeName).Value;
            var clientHandle = Convert.ToInt32(xElement.Attribute(clientHandleAttributeName).Value);

            return new ItemIdentifier(itemId, string.Empty, clientHandle);
        }
    }
}
