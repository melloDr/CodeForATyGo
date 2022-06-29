using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CE.Data.EF
{
    public class CEDbContextFactory : IDesignTimeDbContextFactory<CeDbContext>
    {
        public CeDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            var connectionString = configuration.GetConnectionString("CeDb");
            var optionBuilder = new DbContextOptionsBuilder<CeDbContext>();
            optionBuilder.UseSqlServer(connectionString);

            return new CeDbContext(optionBuilder.Options);
        }
    }
}
