using Kepware.ClientAce.OpcDaClient;
using OpcDataLogger.Interfaces;
using System;

namespace OpcDataLogger.Models.Conditions
{
    public class DeltaCondition : ICondition
    {
        public decimal Delta { get; }

        public DeltaCondition(double delta = 0d) :
            this(Convert.ToDecimal(delta))
        { }

        public DeltaCondition(decimal delta = 0m) =>
            Delta = Math.Abs(delta);

        public bool Check(ItemValueCallback oldItemValue, ItemValueCallback newItemValue) =>
            null == oldItemValue || CheckInternal(Convert.ToDecimal(oldItemValue.Value), Convert.ToDecimal(newItemValue.Value));

        private bool CheckInternal(decimal oldValue, decimal newValue) =>
            newValue <= (oldValue - Delta) || (oldValue + Delta) <= newValue;
    }
}
