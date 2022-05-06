namespace OpcDataLogger.Interfaces
{
    public interface IOpcDataLogger
    {
        bool Connect(string url);
        void Disconnect();
        void Subscribe();
        void SubscriptionModify(bool active);
    }
}