using Microsoft.Data.SqlClient;

namespace STMDotNetCore.PizzaApi
{
    internal static class ConnectionStrings
    {
        public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "SWAMTHUMARN",
            InitialCatalog = "STMDotNetCore",
            UserID = "sa",
            Password = "root",
            TrustServerCertificate = true
        };
    }
}
