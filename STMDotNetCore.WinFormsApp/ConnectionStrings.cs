using System.Data.SqlClient;

namespace STMDotNetCore.WinFormsApp
{
    public class ConnectionStrings
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
