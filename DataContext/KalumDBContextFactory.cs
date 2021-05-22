using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Kalum2021.DataContext
{
    public class KalumDBContextFactory : IDesignTimeDbContextFactory<KalumDBContext>
    {
        public KalumDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
                var optionsBuilder = new DbContextOptionsBuilder<KalumDBContext>();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                return new KalumDBContext(optionsBuilder.Options);
        }
    }
}