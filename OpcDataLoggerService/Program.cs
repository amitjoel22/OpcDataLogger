using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace OpcDataLoggerService
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main()
        {
            var servicesToRun = new ServiceBase[]
            {
                new OpcDataLoggerService(null)
            };
            ServiceBase.Run(servicesToRun);
        }
    }
}
