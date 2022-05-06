using Kepware.ClientAce.OpcDaClient;
using OpcDataLogger.Interfaces;
using OpcDataLogger.Models;
using OpcDataLogger.Models.Conditions;
using OpcDataLogger.Models.EventArgs;
using OpcDataLogger.Models.Factories;
using OpcDataLogger.Models.Repos;
using System;
using System.Linq;

namespace test_KepOpcLogger
{
    class Program
    {
        static IOpcDataLogger dataLogger;

        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);

            //CreateDaServerMgt();

            CreateOpcLogger();

            Console.WriteLine(DateTime.Now);

            Console.ReadKey();
            Console.WriteLine("Stop receive data.");
            dataLogger.SubscriptionModify(false);

            Console.ReadKey();
            Console.WriteLine("Start receive data.");
            dataLogger.SubscriptionModify(true);

            Console.ReadKey();
            Console.WriteLine("Disconnect.");
            dataLogger.Disconnect();
        }

        private static void CreateOpcLogger()
        {
            var items = new ItemIdentifier[]
            {
                //new ItemIdentifier("ns=2;s=_System._Time", string.Empty, -1),
                new ItemIdentifier("ns=2;s=EFL-60.EFL60.Diam.Diam1X", string.Empty, 0),
                new ItemIdentifier("ns=2;s=EFL-60.EFL60.Diam.Diam1Y", string.Empty, 1),
                new ItemIdentifier("ns=2;s=EFL-60.EFL60.Diam.Diam2X", string.Empty, 2),
                new ItemIdentifier("ns=2;s=EFL-60.EFL60.Diam.Diam2Y", string.Empty, 3),
                new ItemIdentifier("ns=2;s=EFL-60.EFL60.Diam.Diam3X", string.Empty, 4),
                new ItemIdentifier("ns=2;s=EFL-60.EFL60.Diam.Diam3Y", string.Empty, 5)
            };

            var sensors = items.Select(iId => (ISensor)new Sensor(iId, new ICondition[] { new DeltaCondition(0.02), new TimeSpanCondition(TimeSpan.FromSeconds(5)) })).ToDictionary(s => Convert.ToInt32(s.ItemIdentifier.ClientHandle), s => s);
            sensors.Add(-1, new Sensor(new ItemIdentifier("ns=2;s=_System._Time", string.Empty, -1), new ICondition[] { new TimeSpanCondition(5) }));

            var url = "opc.tcp://192.168.11.232:49320";

            dataLogger = new DataLogger(new Server(), new DBRepo(), new SensorFactory(new ConditionFactory(), new ItemIdentifierFactory()));
            if (dataLogger.Connect(url))
            {
                dataLogger.Subscribe();
            }
        }

        private static void CreateDaServerMgt()
        {
            var url = "opc.tcp://192.168.11.232:49320";
            var connInfo = new ConnectInfo()
            {
                LocalId = "en",
                KeepAliveTime = 1000,
                RetryAfterConnectionError = true,
                RetryInitialConnection = false,
                ClientName = "Tomskcable Kepware DLL"
            };
            var daServer = new DaServerMgt();
            
            daServer.Connect(url, 1, ref connInfo, out bool connFailed);

            Console.WriteLine(connFailed ? "Conn failed!" : "Conn success!");

            var items = new ItemIdentifier[]
            {
                /*
                new ItemIdentifier
                {
                    ClientHandle = 0,
                    ItemName = "ns=2;s=EFL-60.EFL60.Diam.Diam1X",
                    DataType = Type.GetType("System.Single"),
                },
                */
                /*
                new ItemIdentifier
                {
                    ClientHandle = 1,
                    ItemName = "ns=2;s=EFL-60.EFL60.Diam.Diam1Y",
                    DataType = Type.GetType("System.Single"),
                },
                new ItemIdentifier("ns=2;s=EFL-60.EFL60.Diam.Diam2X", string.Empty),
                new ItemIdentifier("ns=2;s=EFL-60.EFL60.Diam.Diam2Y", string.Empty, 3),
                */
                new ItemIdentifier("ns=2;s=_System._Time", string.Empty, 4),
                
            };

            var conditions = new ICondition[]
            {
                new NotEqualsCondition(),
                //new DeltaCondition(0.1),
                new TimeSpanCondition(TimeSpan.FromSeconds(5)),
            };

            var sensor = new Sensor(items[0], conditions);
            sensor.DataChanged += Sensor_OnDataChanged;

            daServer.Subscribe(1, true, 1000, out int revisedUR, 0, ref items, out int serverSubs);
            daServer.DataChanged += DaServer_DataChanged;
            //daServer.SubscriptionModify(serverSubs, true);
        }

        private static void Sensor_OnDataChanged(object sender, SensorDataChangedEventArgs e)
        {
            Console.WriteLine("Data changed:\t" + GetString(e.ItemValue));
        }

        private static string GetString(ItemValueCallback itemValue)
        {
            return $"Handle:\t{itemValue?.ClientHandle}\tTime stamp:\t{itemValue?.TimeStamp:T}\tNow:\t{DateTime.Now:T}\tValue:\t{itemValue?.Value}\tData type:\t{itemValue?.Value.GetType()}";
        }

        private static void DaServer_DataChanged(int clientSubscription, bool allQualitiesGood, bool noErrors, ItemValueCallback[] itemValues)
        {
            foreach (var itemValue in itemValues)
            {
                //sensor.DataChange(itemValue);
                Console.WriteLine(GetString(itemValue));
            }
        }
    }
}
