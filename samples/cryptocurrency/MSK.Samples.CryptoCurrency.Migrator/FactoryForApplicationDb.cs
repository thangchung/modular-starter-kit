using System;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MSK.Application.Module.Data;
using MSK.Application.Module.Data.Extensions;

namespace MSK.Samples.CryptoCurrency.Migrator
{
    public class FactoryForApplicationDb : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        private readonly IExtendDbContextOptionsBuilder _extendOptionsBuilder;
        private readonly IDatabaseConnectionStringFactory _dbConnectionStringFactory;
        private readonly IConfiguration _config;

        public FactoryForApplicationDb()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .Build();

            _extendOptionsBuilder = new InMemoryDbContextOptionsBuilderFactory();
            _dbConnectionStringFactory = new NoOpDatabaseConnectionStringFactory();
        }

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var migrationAssembly = typeof(FactoryForApplicationDb).GetTypeInfo().Assembly;

            var dbContextOptionBuilder = _extendOptionsBuilder.Extend(
                new DbContextOptionsBuilder<ApplicationDbContext>(),
                _dbConnectionStringFactory,
                migrationAssembly.GetName().Name);

            return (ApplicationDbContext)Activator.CreateInstance(
                typeof(ApplicationDbContext),
                dbContextOptionBuilder.Options);
        }
    }
}
