using Kepware.ClientAce.OpcDaClient;
using NUnit.Framework;
using OpcDataLogger.Models.EventArgs;

namespace OpcLogger_Tests.EventArgsTests
{
    [TestOf(typeof(ServerStateChangedEventArgs))]
    [TestFixture]
    public class ServerStateChangedEventArgs_Tests
    {
        [Test]
        public void Test()
        {
            var clientHandle = 1;
            var state = ServerState.ERRORSHUTDOWN;

            var serverStateChangedEA = new ServerStateChangedEventArgs(clientHandle, state);

            Assert.AreEqual(state, serverStateChangedEA.State);
            Assert.AreEqual(clientHandle, serverStateChangedEA.ClientHandle);
        }
    }
}
