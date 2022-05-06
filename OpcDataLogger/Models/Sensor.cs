using Kepware.ClientAce.OpcDaClient;
using OpcDataLogger.Interfaces;
using OpcDataLogger.Models.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpcDataLogger.Models
{
    public class Sensor : ISensor
    {
        private const string conditionsEmptyMessage = "Пустая коллекция условий";
        private const string conditionsNullMessage = "Коллекция условий не инициализирована";
        private const string conditionsOneNullMessage = "Одно из условий не инициализированно";
        private const string itemIdentifierNullMessage = "Не инициализированный параметр ItemIdentifier";

        private ItemValueCallback _lastItemValue;
        public ItemIdentifier ItemIdentifier { get; }
        private readonly IEnumerable<ICondition> _conditions;

        public event EventHandler<SensorDataChangedEventArgs> DataChanged;
        
        public Sensor(ItemIdentifier itemIdentifier, IEnumerable<ICondition> conditions)
        {
            ItemIdentifier = itemIdentifier ?? throw new ArgumentNullException(itemIdentifierNullMessage);
            _conditions = IsConditionsValid(conditions, out string reason) ? conditions : throw new ArgumentException(reason);
        }

        public void DataChange(ItemValueCallback currentValue)
        {
            if (CheckAllConditions(currentValue))
            {
                _lastItemValue = currentValue;
                DataChanged?.Invoke(this, new SensorDataChangedEventArgs(_lastItemValue));
            }
        }

        private bool CheckAllConditions(ItemValueCallback currentValue) =>
            _conditions.All(c => c.Check(_lastItemValue, currentValue));

        private static bool IsConditionsValid(IEnumerable<ICondition> conditions, out string reason) =>
            string.IsNullOrWhiteSpace(reason = CheckConditionsIsNull(conditions));

        private static string CheckConditionsIsNull(IEnumerable<ICondition> conditions) =>
            null == conditions ? conditionsNullMessage : CheckConditionsIsEmpty(conditions);

        private static string CheckConditionsIsEmpty(IEnumerable<ICondition> conditions) =>
            !conditions.Any() ? conditionsEmptyMessage : CheckConditionsIsOneNull(conditions);

        private static string CheckConditionsIsOneNull(IEnumerable<ICondition> conditions) =>
            conditions.Any(c => null == c) ? conditionsOneNullMessage : string.Empty;
    }
}
