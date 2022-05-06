using OpcDataLogger.Interfaces;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace OpcDataLogger.Models.Repos
{
    public class DBRepo : IRepo
    {
        private static string connectionString;

        static DBRepo()
        {
            var connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.UserID = "potme";
            connStringBuilder.Password = "3651pme";
            connStringBuilder.DataSource = "192.168.11.152";
            connStringBuilder.InitialCatalog = "Technology";
            connStringBuilder.AsynchronousProcessing = true;
            connStringBuilder.ApplicationName = "OPC Data Logger";

            connectionString = connStringBuilder.ToString();
        }

        public XDocument GetXml()
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("ServiceRTPGetLogList", connection) { CommandType = System.Data.CommandType.StoredProcedure })
            {
                connection.Open();
                var xmlReader = command.ExecuteXmlReader();
                return XDocument.Load(xmlReader);
            }
        }
    }
}
