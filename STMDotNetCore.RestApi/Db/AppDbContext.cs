using Microsoft.EntityFrameworkCore;
using STMDotNetCore.RestApi.Models;

namespace STMDotNetCore.RestApi.Db
{
    //public class AppDbContext
    //{
    //}
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }

        public DbSet<BlogModel> Blogs { get; set; }
    }
}
