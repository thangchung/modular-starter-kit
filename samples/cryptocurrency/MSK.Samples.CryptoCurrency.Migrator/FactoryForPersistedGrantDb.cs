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

namespace MSK.Samples.CryptoCurrency.Migrator
{
    public class FactoryForPersistedGrantDb : IDesignTimeDbContextFactory<PersistedGrantDbContext>
    {
        private readonly IExtendDbContextOptionsBuilder _extendOptionsBuilder;
        private readonly IDatabaseConnectionStringFactory _dbConnectionStringFactory;
        private readonly IConfiguration _config;

        public FactoryForPersistedGrantDb()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .Build();

            _extendOptionsBuilder = new InMemoryDbContextOptionsBuilderFactory();
            _dbConnectionStringFactory = new NoOpDatabaseConnectionStringFactory();
        }

        public PersistedGrantDbContext CreateDbContext(string[] args)
        {
            var migrationAssembly = typeof(FactoryForPersistedGrantDb).GetTypeInfo().Assembly;

            var dbContextOptionBuilder = _extendOptionsBuilder.Extend(
                new DbContextOptionsBuilder<PersistedGrantDbContext>(),
                _dbConnectionStringFactory,
                migrationAssembly.GetName().Name);

            return (PersistedGrantDbContext)Activator.CreateInstance(
                typeof(PersistedGrantDbContext),
                dbContextOptionBuilder.Options,
                new OperationalStoreOptions());
        }
    }
}
