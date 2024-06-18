using System.Data.SqlClient;

namespace STMDotNetCore.RestApi
{
    public class ConnectionStrings
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
