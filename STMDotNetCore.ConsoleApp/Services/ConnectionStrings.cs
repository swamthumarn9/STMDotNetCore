using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMDotNetCore.ConsoleApp.Services
{
    internal class ConnectionStrings
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "SWAMTHUMARN",
            InitialCatalog = "STMDotNetCore",
            UserID = "sa",
            Password = "root",
            TrustServerCertificate = true
        };        
    }
}
