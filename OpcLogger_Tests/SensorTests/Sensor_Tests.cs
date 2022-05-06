using Kepware.ClientAce.OpcDaClient;
using NSubstitute;
using NUnit.Framework;
using OpcDataLogger.Interfaces;
using OpcDataLogger.Models;
using OpcDataLogger.Models.Conditions;
using System;
using System.Linq;

namespace OpcLogger_Tests.SensorTests
{
    [TestOf(typeof(Sensor))]
    [TestFixture]
    public class Sensor_Tests
    {
        [Test]
        public void NullConditions_ThrowArgumentException_Test()
        {
            var itemIdentifier = new ItemIdentifier();
            Assert.Throws<ArgumentException>(() => new Sensor(itemIdentifier, null));
        }

        [Test]
        public void EmptyConditions_ThrowArgumentException_Test()
        {
            var itemIdentifier = new ItemIdentifier();
            Assert.Throws<ArgumentException>(() => new Sensor(itemIdentifier, Enumerable.Empty<ICondition>()));
        }

        [Test]
        public void OneNullCondition_ThrowArgumentException_Test()
        {
            var itemIdentifier = new ItemIdentifier();
            var conditions = new ICondition[] { null };
            Assert.Throws<ArgumentException>(() => new Sensor(itemIdentifier, conditions));
        }

        [Test]
        public void NullItemIdentifier_ThrowArgumentNullException_Test()
        {
            ItemIdentifier itemIdentifier = null;
            var conditions = new ICondition[] { Substitute.For<ICondition>() };
            Assert.Throws<ArgumentNullException>(() => new Sensor(itemIdentifier, conditions));
        }

        [Test]
        public void SetItemIdentifier_Success_Test()
        {
            var itemIdentifier = new ItemIdentifier();
            var conditions = new ICondition[] { Substitute.For<ICondition>() };

            var sensor = new Sensor(itemIdentifier, conditions);

            Assert.AreEqual(itemIdentifier, sensor.ItemIdentifier);
        }

        [Test]
        public void NotEqualsCondition_FirstEvent_DataChangedEventFire_Success_Test()
        {
            var isEventFire = false;
            var countEventFire = 0;

            var itemIdentifier = new ItemIdentifier();
            var conditions = new ICondition[] { new NotEqualsCondition() };
            var itemValue = new ItemValueCallback() { Value = 0.5 };
            var sensor = new Sensor(itemIdentifier, conditions);

            sensor.DataChanged += (s, e) =>
            {
                countEventFire++;
                isEventFire = true;
            };
            
            sensor.DataChange(itemValue);

            Assert.IsTrue(isEventFire);
            Assert.AreEqual(1, countEventFire);
        }

        [Test]
        public void TimeSpanCondition_FirstEvent_DataChangedEventFire_Success_Test()
        {
            var now = DateTime.Now;
            var isEventFire = false;
            var countEventFire = 0;

            var itemIdentifier = new ItemIdentifier();
            var conditions = new ICondition[] { new TimeSpanCondition(TimeSpan.FromSeconds(10)) };
            var itemValue = new ItemValueCallback() { TimeStamp = now };
            var sensor = new Sensor(itemIdentifier, conditions);

            sensor.DataChanged += (s, e) =>
            {
                countEventFire++;
                isEventFire = true;
            };

            sensor.DataChange(itemValue);

            Assert.IsTrue(isEventFire);
            Assert.AreEqual(1, countEventFire);
        }


        [Test]
        public void TimeSpanCondition_FewEvents_DataChangedEventFire_Success_Test()
        {
            var now = DateTime.Now;
            var isEventFire = false;
            var countEventFire = 0;

            var itemIdentifier = new ItemIdentifier();
            var conditions = new ICondition[] { new TimeSpanCondition(TimeSpan.FromSeconds(10)) };
            var firstItemValue = new ItemValueCallback() { TimeStamp = now };
            var secondItemValue = new ItemValueCallback() { TimeStamp = now.AddSeconds(15)};
            var sensor = new Sensor(itemIdentifier, conditions);

            sensor.DataChanged += (s, e) =>
            {
                countEventFire++;
                isEventFire = true;
            };

            sensor.DataChange(firstItemValue);
            sensor.DataChange(secondItemValue);

            Assert.IsTrue(isEventFire);
            Assert.AreEqual(2, countEventFire);
        }

        [Test]
        public void TimeSpanCondition_FewEvents_DataChangedEventFire_Fail_Test()
        {
            var now = DateTime.Now;
            var isEventFire = false;
            var countEventFire = 0;

            var itemIdentifier = new ItemIdentifier();
            var conditions = new ICondition[] { new TimeSpanCondition(TimeSpan.FromSeconds(10)) };
            var firstItemValue = new ItemValueCallback() { TimeStamp = now };
            var secondItemValue = new ItemValueCallback() { TimeStamp = now.AddSeconds(5) };
            var sensor = new Sensor(itemIdentifier, conditions);

            sensor.DataChanged += (s, e) =>
            {
                countEventFire++;
                isEventFire = true;
            };

            sensor.DataChange(firstItemValue);
            sensor.DataChange(secondItemValue);

            Assert.IsTrue(isEventFire);
            Assert.AreEqual(1, countEventFire);
        }

        [Test]
        public void NotEqualsCondition_FewEvents_DataChangedEventFire_Success_Test()
        {
            var isEventFire = false;
            var countEventFire = 0;

            var itemIdentifier = new ItemIdentifier();
            var conditions = new ICondition[] { new NotEqualsCondition()};
            var firstItemValue = new ItemValueCallback() { Value = 0.5 };
            var secondItemValue = new ItemValueCallback() { Value = 0.7 };
            var sensor = new Sensor(itemIdentifier, conditions);

            sensor.DataChanged += (s, e) =>
            {
                countEventFire++;
                isEventFire = true;
            };

            sensor.DataChange(firstItemValue);
            sensor.DataChange(secondItemValue);

            Assert.IsTrue(isEventFire);
            Assert.AreEqual(2, countEventFire);
        }

        [Test]
        public void NotEqualsCondition_FewEvents_DataChangedEventFire_Fail_Test()
        {
            var isEventFire = false;
            var countEventFire = 0;

            var itemIdentifier = new ItemIdentifier();
            var conditions = new ICondition[] { new NotEqualsCondition() };
            var firstItemValue = new ItemValueCallback() { Value = 0.5 };
            var secondItemValue = new ItemValueCallback() { Value = 0.5 };
            var sensor = new Sensor(itemIdentifier, conditions);

            sensor.DataChanged += (s, e) =>
            {
                countEventFire++;
                isEventFire = true;
            };

            sensor.DataChange(firstItemValue);
            sensor.DataChange(secondItemValue);

            Assert.IsTrue(isEventFire);
            Assert.AreEqual(1, countEventFire);
        }

        [Test]
        public void DeltaCondition_FewEvents_DataChangedEventFire_Success_Test()
        {
            var now = DateTime.Now;
            var isEventFire = false;
            var countEventFire = 0;

            var itemIdentifier = new ItemIdentifier();
            var conditions = new ICondition[] { new DeltaCondition(0.5m) };
            var firstItemValue = new ItemValueCallback() { Value = 1.0 };
            var secondItemValue = new ItemValueCallback() { Value = 1.5 };
            var thirdItemValue = new ItemValueCallback() { Value = 0.5 };
            var sensor = new Sensor(itemIdentifier, conditions);

            sensor.DataChanged += (s, e) =>
            {
                countEventFire++;
                isEventFire = true;
            };

            sensor.DataChange(firstItemValue);
            sensor.DataChange(secondItemValue);
            sensor.DataChange(thirdItemValue);

            Assert.IsTrue(isEventFire);
            Assert.AreEqual(3, countEventFire);
        }

        [Test]
        public void DeltaCondition_FewEvents_DataChangedEventFire_Fail_Test()
        {
            var now = DateTime.Now;
            var isEventFire = false;
            var countEventFire = 0;

            var itemIdentifier = new ItemIdentifier();
            var conditions = new ICondition[] { new DeltaCondition(0.5m)};
            var firstItemValue = new ItemValueCallback() { Value = 1.0 };
            var secondItemValue = new ItemValueCallback() { Value = 1.4 };
            var thirdItemValue = new ItemValueCallback() { Value = 0.6 };
            var sensor = new Sensor(itemIdentifier, conditions);

            sensor.DataChanged += (s, e) =>
            {
                countEventFire++;
                isEventFire = true;
            };

            sensor.DataChange(firstItemValue);
            sensor.DataChange(secondItemValue);
            sensor.DataChange(thirdItemValue);

            Assert.IsTrue(isEventFire);
            Assert.AreEqual(1, countEventFire);
        }
    }
}
