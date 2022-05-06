using Kepware.ClientAce.OpcDaClient;
using OpcDataLogger.Interfaces;
using System;

namespace OpcDataLogger.Models.Conditions
{
    public class TimeSpanCondition : ICondition
    {
        private const string zeroPeriodMessage = "Период не может быть равен 0";

        public TimeSpan TimeSpan { get; }

        public TimeSpanCondition(double timeSpan) : this(TimeSpan.FromSeconds(timeSpan))
        { }

        public TimeSpanCondition(TimeSpan timeSpan) =>
            TimeSpan = TimeSpan.Zero != timeSpan ? timeSpan : throw new ArgumentException(zeroPeriodMessage);

        public bool Check(ItemValueCallback oldItemValue, ItemValueCallback newItemValue) =>
            null == oldItemValue || oldItemValue.TimeStamp.Add(TimeSpan) < newItemValue.TimeStamp;
    }
}
