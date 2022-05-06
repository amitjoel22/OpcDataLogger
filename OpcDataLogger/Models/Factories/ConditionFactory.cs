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
            var type = DefineConditionType(xElement.Attribute(typeAttributeName));

            return null == valueAttribute ? CallEmptyCtor(type) : CallParamsCtor(type, Convert.ToDouble(valueAttribute.Value));
        }

        private static Type DefineConditionType(XAttribute typeAttribute) =>
            Type.GetType(conditionType.Replace(classNamePlaceholder, typeAttribute.Value));

        private static ICondition CallEmptyCtor(Type type) =>
            (ICondition)Activator.CreateInstance(type);

        private static ICondition CallParamsCtor(Type type, double arg) =>
            (ICondition)Activator.CreateInstance(type, arg);
    }
}
