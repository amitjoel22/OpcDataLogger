using OpcDataLogger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace OpcDataLogger.Models.Factories
{
    public class SensorFactory : ISensorFactory
    {
        private const string conditionElementName = "Condition";

        private readonly IConditionFactory _conditionFactory;
        private readonly IItemIdentifierFactory _itemIdentifierFactory;

        public SensorFactory(IConditionFactory conditionFactory, IItemIdentifierFactory itemIdentifierFactory) =>
            (_conditionFactory, _itemIdentifierFactory) = (conditionFactory, itemIdentifierFactory);

        public ISensor CreateInstance(XElement xElement) =>
            (ISensor)Activator.CreateInstance(typeof(Sensor), GetItemIdentifier(xElement), GetConditions(xElement));

        private Kepware.ClientAce.OpcDaClient.ItemIdentifier GetItemIdentifier(XElement xElement) =>
            _itemIdentifierFactory.CreateInstance(xElement);

        private IEnumerable<ICondition> GetConditions(XElement xElement) =>
            xElement.Descendants(conditionElementName).Select(c => _conditionFactory.CreateInstance(c)).ToArray();
    }
}
