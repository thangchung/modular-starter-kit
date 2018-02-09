using System;
using System.IO;
using System.Reflection;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MSK.Application.Module.Data;
using MSK.Application.Module.Data.Extensions;

namespace MSK.Samples.BiMonetary.Migrator
{
    public class FactoryForConfigurationDb : IDesignTimeDbContextFactory<ConfigurationDbContext>
    {
        private readonly IExtendDbContextOptionsBuilder _extendOptionsBuilder;
        private readonly IDatabaseConnectionStringFactory _dbConnectionStringFactory;
        private readonly IConfiguration _config;

        public FactoryForConfigurationDb()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .Build();

            _extendOptionsBuilder = new InMemoryDbContextOptionsBuilderFactory();
            _dbConnectionStringFactory = new NoOpDatabaseConnectionStringFactory();
        }

        public ConfigurationDbContext CreateDbContext(string[] args)
        {
            var migrationAssembly = typeof(FactoryForConfigurationDb).GetTypeInfo().Assembly;

            var dbContextOptionBuilder = _extendOptionsBuilder.Extend(
                new DbContextOptionsBuilder<ConfigurationDbContext>(),
                _dbConnectionStringFactory,
                migrationAssembly.GetName().Name);

            return (ConfigurationDbContext)Activator.CreateInstance(
                typeof(ConfigurationDbContext),
                dbContextOptionBuilder.Options,
                new ConfigurationStoreOptions());
        }
    }
}
