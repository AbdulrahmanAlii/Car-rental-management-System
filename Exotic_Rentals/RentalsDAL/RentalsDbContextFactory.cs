using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RentalsDAL.Model;
using System.Configuration;

namespace RentalsDAL
{
    internal class RentalsDbContextFactory : IDesignTimeDbContextFactory<RentalsDbContext>
    {
        public RentalsDbContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RentalsDbContext>();

            var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

            optionsBuilder.UseSqlServer(connectionString);

            return new RentalsDbContext(optionsBuilder.Options);
        }
    }
}