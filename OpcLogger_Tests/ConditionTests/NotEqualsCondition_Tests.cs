using Kepware.ClientAce.OpcDaClient;
using NUnit.Framework;
using OpcDataLogger.Interfaces;
using OpcDataLogger.Models.Conditions;

namespace OpcLogger_Tests.ConditionTests
{
    [TestOf(typeof(NotEqualsCondition))]
    [TestFixture]
    public class NotEqualsCondition_Tests
    {
        [Test]
        public void DiffValues_Success_Test()
        {
            var oldValue = new ItemValueCallback() { Value = 0.5 };
            var newValue = new ItemValueCallback() { Value = 1.5 };

            ICondition condition = new NotEqualsCondition();

            var result = condition.Check(oldValue, newValue);

            Assert.IsTrue(result);
        }

        [Test]
        public void SameValues_Fail_Test()
        {
            var oldValue = new ItemValueCallback() { Value = 0.5 };
            var newValue = new ItemValueCallback() { Value = 0.5 };

            ICondition condition = new NotEqualsCondition();

            var result = condition.Check(oldValue, newValue);

            Assert.IsFalse(result);
        }

        [Test]
        public void OldValueIsNull_Success_Test()
        {
            ICondition condition = new NotEqualsCondition();

            ItemValueCallback oldValue = null;
            var newValue = new ItemValueCallback() { Value = 0.7 };

            var result = condition.Check(oldValue, newValue);
            Assert.IsTrue(result);
        }
    }
}
