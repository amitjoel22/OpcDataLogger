using Kepware.ClientAce.OpcDaClient;
using NUnit.Framework;
using OpcDataLogger.Models.EventArgs;
using System;

namespace OpcLogger_Tests.EventArgsTests
{
    [TestOf(typeof(ServerDataChangedEventArgs))]
    [TestFixture]
    public class ServerDataChangedEventArgs_Tests
    {
        [Test]
        public void CreateEventArgs_Test()
        {
            var clientSubscription = 1;
            var allQualitiesGood = true;
            var noErrors = true;
            var itemValues = Array.Empty<ItemValueCallback>();

            var serverDataChangedEA = new ServerDataChangedEventArgs(clientSubscription, allQualitiesGood, noErrors, itemValues);

            Assert.AreEqual(clientSubscription, serverDataChangedEA.ClientSubscription);
            Assert.IsTrue(serverDataChangedEA.AllQualitiesGood);
            Assert.IsTrue(serverDataChangedEA.NoErrors);
            Assert.AreEqual(itemValues, serverDataChangedEA.ItemValues);
        }
    }
}
