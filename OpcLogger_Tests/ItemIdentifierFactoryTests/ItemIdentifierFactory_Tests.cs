using Kepware.ClientAce.OpcDaClient;
using NUnit.Framework;
using OpcDataLogger.Interfaces;
using OpcDataLogger.Models.Factories;
using System.Xml.Linq;

namespace OpcLogger_Tests.ItemIdentifierFactoryTests
{
    [TestOf(typeof(ItemIdentifierFactory))]
    [TestFixture]
    public class ItemIdentifierFactory_Tests
    {
        private IItemIdentifierFactory _itemIdentifierFactory;

        [SetUp]
        public void Setup()
        {
            _itemIdentifierFactory = new ItemIdentifierFactory();
        }

        [Test]
        public void CreateItemIdentifier_Success_Test()
        {
            var xElement = new XElement("Tag", new XAttribute("id_log", "2489"), new XAttribute("OPC_Tag", "ns=2;s=SET.KTP-100.Ia"));
            var itemIdentifier = _itemIdentifierFactory.CreateInstance(xElement);

            Assert.NotNull(itemIdentifier);
            Assert.IsInstanceOf<ItemIdentifier>(itemIdentifier);
        }
    }
}
