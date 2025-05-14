using Oracle.ManagedDataAccess.Client;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace OracleUserManager.Models
{
    public class OracleDbConnection
    {
        public string Hostname { get; set; } = string.Empty;
        public int Port { get; set; } = 1521;
        public string SID { get; set; } = "xe";  // Default SID for Oracle XE
        public string ServiceName { get; set; } = string.Empty;  // New property for Service Name
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "default";  // Only keeping default role

        public string GetConnectionString()
        {
            string connectData;
            if (!string.IsNullOrEmpty(ServiceName))
            {
                connectData = $"(SERVICE_NAME={ServiceName})";
            }
            else
            {
                connectData = $"(SID={SID})";
            }

            string connectionString = $"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={Hostname})(PORT={Port}))" +
                                   $"(CONNECT_DATA={connectData}));User Id={Username};Password={Password}";

            return connectionString;
        }

        public bool TestConnection()
        {
            try
            {
                using var conn = new OracleConnection(GetConnectionString());
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
} 