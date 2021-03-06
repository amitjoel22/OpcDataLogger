using OpcDataLogger.Interfaces;
using System;
using System.Xml.Linq;

namespace OpcDataLogger.Models.Factories
{
    public class ConditionFactory : IConditionFactory
    {
        private const string typeAttributeName = "Type";
        private const string valueAttributeName = "Value";
        private const string classNamePlaceholder = "{className}";
        private const string conditionType = "OpcDataLogger.Models.Conditions.{className}Condition";

        public ICondition CreateInstance(XElement xElement)
        {
            var valueAttribute = xElement.Attribute(valueAttributeName);
            var type = GetConditionType(xElement.Attribute(typeAttributeName));

            return (ICondition)Activator.CreateInstance(type, ConvertInternal(valueAttribute));
        }

        private object[] ConvertInternal(XAttribute valueAttribute) =>
            null == valueAttribute ? null : new object[] { Convert.ToDouble(valueAttribute.Value) };

        private static Type GetConditionType(XAttribute typeAttribute) =>
            Type.GetType(conditionType.Replace(classNamePlaceholder, typeAttribute.Value));
    }
}
