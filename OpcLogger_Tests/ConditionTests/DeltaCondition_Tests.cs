using Kepware.ClientAce.OpcDaClient;
using NUnit.Framework;
using OpcDataLogger.Interfaces;
using OpcDataLogger.Models.Conditions;
using System;

namespace OpcLogger_Tests.ConditionTests
{
    [TestOf(typeof(DeltaCondition))]
    [TestFixture]
    public class DeltaCondition_Tests
    {
        [Test]
        public void SetDecimalDelta_Success_Test()
        {
            var delta = 1.0m;
            var condition = new DeltaCondition(delta);
            Assert.AreEqual(delta, condition.Delta);
        }

        [Test]
        public void SetDoubleDelta_Success_Test()
        {
            var doubleDelta = 1.0d;
            var expectedDecimalDelta = Convert.ToDecimal(doubleDelta);
            var condition = new DeltaCondition(doubleDelta);
            Assert.AreEqual(expectedDecimalDelta, condition.Delta);
        }

        [Test]
        public void OldValueIsNull_NewValueIsZero_Success_Test()
        {
            var delta = 0.5m;
            ICondition condition = new DeltaCondition(delta);

            ItemValueCallback oldItemValue = null;
            var newItemValue = new ItemValueCallback() { Value = 0 };

            var result = condition.Check(oldItemValue, newItemValue);
            Assert.IsTrue(result);
        }

        [Test]
        public void OldValueIsNull_NewValue_Success_Test()
        {
            var delta = 0.5m;
            ICondition condition = new DeltaCondition(delta);

            ItemValueCallback oldItemValue = null;
            var newItemValue = new ItemValueCallback() { Value = 1 };

            var result = condition.Check(oldItemValue, newItemValue);
            Assert.IsTrue(result);
        }

        [Test]
        public void SameValues_Fail_Test()
        {
            var delta = 0.5m;
            ICondition condition = new DeltaCondition(delta);

            var oldItemValue = new ItemValueCallback() { Value = 0.7 };
            var newItemValue = new ItemValueCallback() { Value = 0.7 };

            var result = condition.Check(oldItemValue, newItemValue);
            Assert.IsFalse(result);
        }

        [Test]
        public void DiffValues_GreaterThanDelta_Success_Test()
        {
            var delta = 0.4m;
            ICondition condition = new DeltaCondition(delta);

            var oldItemValue = new ItemValueCallback() { Value = 0.7 };
            var newItemValue = new ItemValueCallback() { Value = 1.2 };

            var result = condition.Check(oldItemValue, newItemValue);

            Assert.IsTrue(result);
        }

        [Test]
        public void DiffValues_SmallerThanDelta_Success_Test()
        {
            var delta = 0.4m;
            ICondition condition = new DeltaCondition(delta);

            var oldItemValue = new ItemValueCallback() { Value = 0.7 };
            var newItemValue = new ItemValueCallback() { Value = 0.2 };

            var result = condition.Check(oldItemValue, newItemValue);

            Assert.IsTrue(result);
        }
    }
}
