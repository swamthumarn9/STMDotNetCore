using System.Data.SqlClient;

namespace STMDotNetCore.RestApiWithNLayer
{
    public class ConnectionStrings
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "STM\\MSSQLSERVER2022",
            InitialCatalog = "STMDotNetCore",
            UserID = "sa",
            Password = "root",
            TrustServerCertificate = true
        };
    }
}
