using NUnit.Framework;
using OpcDataLogger.Interfaces;
using OpcDataLogger.Models.Conditions;
using OpcDataLogger.Models.Factories;
using System.Xml.Linq;

namespace OpcLogger_Tests.ConditionFactoryTests
{
    [TestOf(typeof(ConditionFactory))]
    [TestFixture]
    public class ConditionFactory_Tests
    {
        private IConditionFactory conditionFactory;

        [SetUp]
        public void Setup()
        {
            conditionFactory = new ConditionFactory();
        }

        [Test]
        public void GetNotEqualsCondition_Success_Test()
        {
            var xElement = new XElement("Condition", new XAttribute("Type", "NotEquals"));
            var condition = conditionFactory.CreateInstance(xElement);
            Assert.IsInstanceOf<NotEqualsCondition>(condition);
        }

        [Test]
        public void GetAlwaysPassConditions_Success_Test()
        {
            var xElement = new XElement("Condition", new XAttribute("Type", "AlwaysPass"));
            var condition = conditionFactory.CreateInstance(xElement);
            Assert.IsInstanceOf<AlwaysPassCondition>(condition);
        }

        [Test]
        public void GetDeltaCondition_Success_Test()
        {
            var xElement = new XElement("Condition", new XAttribute("Type", "Delta"), new XAttribute("Value", "10"));
            var condition = conditionFactory.CreateInstance(xElement);
            Assert.IsInstanceOf<DeltaCondition>(condition);
        }

        [Test]
        public void GetTimeSpanCondition_Success_Test()
        {
            var xElement = new XElement("Condition", new XAttribute("Type", "TimeSpan"), new XAttribute("Value", "10"));
            var condition = conditionFactory.CreateInstance(xElement);
            Assert.IsInstanceOf<TimeSpanCondition>(condition);
        }
    }
}
