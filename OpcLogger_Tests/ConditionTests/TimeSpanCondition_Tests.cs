using Kepware.ClientAce.OpcDaClient;
using NUnit.Framework;
using OpcDataLogger.Interfaces;
using OpcDataLogger.Models.Conditions;
using System;

namespace OpcLogger_Tests.ConditionTests
{
    [TestOf(typeof(TimeSpanCondition))]
    [TestFixture]
    public class TimeSpanCondition_Tests
    {
        [Test]
        public void PeriodTooSmall_ThrowException_Test()
        {
            Assert.Throws<ArgumentException>(() => new TimeSpanCondition(TimeSpan.Zero));
        }

        [Test]
        public void SetPeriod_Success_Test()
        {
            var timeSpan = TimeSpan.FromSeconds(60);
            var condition = new TimeSpanCondition(timeSpan);

            Assert.AreEqual(timeSpan, condition.TimeSpan);
        }

        [Test]
        public void OldValueIsNull_Success_Test()
        {
            var timeSpan = TimeSpan.FromSeconds(30);
            ICondition condition = new TimeSpanCondition(timeSpan);

            ItemValueCallback oldValue = null;
            var newValue = new ItemValueCallback() { Value = 0.7 };

            var result = condition.Check(oldValue, newValue);
            Assert.IsTrue(result);
        }

        [Test]
        public void SmallPeriod_Fail_Test()
        {
            var timeSpan = TimeSpan.FromSeconds(30);
            ICondition condition = new TimeSpanCondition(timeSpan);

            var now = DateTime.Now;
            var oldValue = new ItemValueCallback() { TimeStamp = now };
            var newValue = new ItemValueCallback() { TimeStamp = now + TimeSpan.FromSeconds(25) };

            var result = condition.Check(oldValue, newValue);

            Assert.IsFalse(result);
        }

        [Test]
        public void BigPeriod_Success_Test()
        {
            var timeSpan = TimeSpan.FromSeconds(30);
            ICondition condition = new TimeSpanCondition(timeSpan);

            var now = DateTime.Now;
            var oldValue = new ItemValueCallback() { TimeStamp = now };
            var newValue = new ItemValueCallback() { TimeStamp = now + TimeSpan.FromSeconds(35) };

            var result = condition.Check(oldValue, newValue);

            Assert.IsTrue(result);
        }
    }
}
