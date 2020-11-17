using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace pShopSolution.Data.EF
{
    public class PShopSolutionDbContextFactory : IDesignTimeDbContextFactory<PShopDbContext>
    {
        public PShopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())  //Install Configuration.FileExtension
                .AddJsonFile("appsetting.json")
                .Build();

            var connectionString = configuration.GetConnectionString("pShopSolutionDb");

            var optionsBuilder = new DbContextOptionsBuilder<PShopDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new PShopDbContext(optionsBuilder.Options);
        }
    }
}