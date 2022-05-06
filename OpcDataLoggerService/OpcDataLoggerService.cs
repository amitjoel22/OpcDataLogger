using OpcDataLogger.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace OpcDataLoggerService
{
    public partial class OpcDataLoggerService : ServiceBase
    {
        private readonly IOpcDataLogger _opcDataLogger;

        private OpcDataLoggerService()
        {
            InitializeComponent();
        }

        public OpcDataLoggerService(IOpcDataLogger opcDataLogger) :
            this() => _opcDataLogger = opcDataLogger;

        protected override void OnStart(string[] args)
        {
            //_opcDataLogger.Connect(string.Empty);
            _opcDataLogger.SubscriptionModify(true);
        }

        protected override void OnStop()
        {
            //_opcDataLogger.Disconnect();
            _opcDataLogger.SubscriptionModify(false);
        }
    }
}
