using Kepware.ClientAce.OpcDaClient;
using NUnit.Framework;
using OpcDataLogger.Models.EventArgs;

namespace OpcLogger_Tests.EventArgsTests
{
    [TestOf(typeof(SensorDataChangedEventArgs))]
    [TestFixture]
    public class SensorDataChangedEventArgs_Tests
    {
        [Test]
        public void CreateEventArgs_Test()
        {
            var itemValue = new ItemValueCallback();

            var sensorDataChangedEA = new SensorDataChangedEventArgs(itemValue);

            Assert.AreEqual(itemValue, sensorDataChangedEA.ItemValue);
        }
    }
}
