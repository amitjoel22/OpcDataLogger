using NUnit.Framework;
using OpcDataLogger.Interfaces;
using OpcDataLogger.Models.Factories;
using System.Linq;
using System.Xml.Linq;

namespace OpcLogger_Tests.SensorFactoryTests
{
    [TestOf(typeof(SensorFactory))]
    [TestFixture]
    public partial class SensorFactory_Tests
    {
        private XDocument xDoc;
        private ISensorFactory _sensorFactory;

        [SetUp]
        public void Setup()
        {
            xDoc = XDocument.Parse(xml);

            var conditionFactory = new ConditionFactory();
            var itemIdentifierFactory = new ItemIdentifierFactory();
            _sensorFactory = new SensorFactory(conditionFactory, itemIdentifierFactory);
        }

        [Test]
        public void CreateSensorsFromXML_Success_Test()
        {
            var expectedSensorCount = 60;
            var sensors = xDoc.Descendants("Tag").Select(t => _sensorFactory.CreateInstance(t)).ToArray();

            Assert.IsNotEmpty(sensors);
            Assert.AreEqual(expectedSensorCount, sensors.Length);
        }
    }
}
