using Kepware.ClientAce.OpcDaClient;
using NUnit.Framework;
using OpcDataLogger.Models.Conditions;

namespace OpcLogger_Tests.ConditionTests
{
    [TestOf(typeof(AlwaysPassCondition))]
    [TestFixture]
    public class AlwaysPassCondition_Tests
    {
        [Test]
        public void AlwaysPass_Success_Test()
        {
            ItemValueCallback oldItemValue = null;
            var newItemValue = new ItemValueCallback();

            var condition = new AlwaysPassCondition();
            Assert.IsTrue(condition.Check(oldItemValue, newItemValue));
        }
    }
}
