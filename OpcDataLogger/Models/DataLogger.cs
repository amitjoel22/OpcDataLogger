using Kepware.ClientAce.OpcDaClient;
using NLog;
using OpcDataLogger.Interfaces;
using OpcDataLogger.Models.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpcDataLogger.Models
{
    public class DataLogger : IOpcDataLogger
    {
        private const string tagElementName = "Tag";

        private static readonly ILogger _logger;

        private readonly int _updateRate = 1000;
        private readonly int _clientHandle = 1024;
        private readonly int _keepAliveTime = 5000;
        private readonly int _clientSubscription = 1;
        private int _serverSubscription = -1;

        private readonly IRepo _repo;
        private readonly IServer _server;
        private readonly ISensorFactory _sensorFactory;
        private IDictionary<int, ISensor> _sensors;

        static DataLogger() =>
            _logger = LogManager.GetCurrentClassLogger();

        public DataLogger(IServer server, IRepo repo, ISensorFactory sensorFactory)
        {
            _repo = repo;
            _server = server;
            _sensorFactory = sensorFactory;

            GetSensors();
            SubscribeToEvents();
        }

        private void GetSensors()
        {
            var xDoc = _repo.GetXml();
            _sensors = xDoc.Descendants(tagElementName).Select(t => _sensorFactory.CreateInstance(t)).ToDictionary(s => Convert.ToInt32(s.ItemIdentifier.ClientHandle), s => s);
        }

        private void SubscribeToEvents()
        {
            _server.DataChanged += Server_DataChanged;

            foreach (var sensor in _sensors.Values)
            {
                sensor.DataChanged += Sensor_DataChanged;
            }
        }

        public bool Connect(string url)
        {
            try
            {
                return _server.Connect(url, _clientHandle, false, true, _keepAliveTime);
            }
            catch (OPCException opcExc)
            {
                // TODO Write to Windows logs
                return false;
            }
        }

        public void Disconnect()
        {
            _server.Disconnect();
            LogManager.Shutdown();
        }

        public void Subscribe()
        {
            var items = _sensors.Values.Select(s => s.ItemIdentifier).ToArray();
            _server.Subscribe(_clientSubscription, true, _updateRate, ref items, out int _, out _serverSubscription);
        }

        public void SubscriptionModify(bool active) =>
            _server.SubscriptionModify(_serverSubscription, active);

        private void Server_DataChanged(object sender, ServerDataChangedEventArgs e)
        {
            foreach (var itemValue in GetGoodItemValues(e))
            {
                _sensors.TryGetValue(Convert.ToInt32(itemValue.ClientHandle), out ISensor sensor);
                sensor?.DataChange(itemValue);
            }
        }

        private static IEnumerable<ItemValueCallback> GetGoodItemValues(ServerDataChangedEventArgs e) =>
            e.ItemValues.Where(v => v.ResultID.Succeeded && QualityID.OPC_QUALITY_GOOD == v.Quality);

        private void Sensor_DataChanged(object sender, SensorDataChangedEventArgs e) =>
            _logger.Info("{itemValue}", e.ItemValue);
    }
}
