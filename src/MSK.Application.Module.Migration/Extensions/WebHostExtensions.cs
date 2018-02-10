using System;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MSK.Core.Module.Utils.Extensions;

namespace MSK.Application.Module.Migration.Extensions
{
    public static class WebHostExtensions
    {
        public static IWebHost RegisterDbContexts(this IWebHost webHost)
        {
            return webHost
                .MigrateDbContext<PersistedGrantDbContext>((_, __) => { })
                .MigrateDbContext<ConfigurationDbContext>((context, services) =>
                {
                    InstanceSeedData(services, context, typeof(IAuthConfigSeedData<>));
                })
                .MigrateDbContext<Data.ApplicationDbContext>((context, services) =>
                {
                    InstanceSeedData(services, context, typeof(ISeedData<>));
                });
        }

        internal static IWebHost MigrateDbContext<TContext>(this IWebHost webHost, Action<TContext, IServiceProvider> seeder)
            where TContext : DbContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                scope.ServiceProvider.MigrateDbContext(seeder);
            }

            return webHost;
        }

        public static void InstanceSeedData(this IServiceProvider resolver, DbContext context, Type seedData)
        {
            var configuration = resolver.GetService<IConfiguration>();
            var scanAssemblyPattern = configuration["ScanAssemblyPattern"];
            var seeders = scanAssemblyPattern.ResolveModularGenericTypes(seedData, context.GetType());

            if (seeders == null) return;

            foreach (var seeder in seeders)
            {
                var seedInstance = Activator.CreateInstance(seeder, new[] { configuration });

                if (seedInstance != null)
                {
                    var method = seeder.GetMethod("SeedAsync");
                    ((Task) method.Invoke(seedInstance, new[] {context})).Wait();
                }
            }
        }

        /// <summary>
        /// This function will open up the door to make the Setup page
        /// Because we can call to this function for provision new database
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <param name="serviceProvider"></param>
        /// <param name="seeder"></param>
        /// <returns></returns>
        public static IServiceProvider MigrateDbContext<TContext>(
            this IServiceProvider serviceProvider,
            Action<TContext, IServiceProvider> seeder) 
            where TContext : DbContext
        {
            var logger = serviceProvider.GetRequiredService<ILogger<TContext>>();
            var context = serviceProvider.GetService<TContext>();

            try
            {
                logger.LogInformation($"Migrating database associated with context {typeof(TContext).Name}");

                // http://www.stefanhendriks.com/2016/04/29/integration-testing-your-dot-net-core-app-with-an-in-memory-database/
                context.Database.OpenConnection();
                context.Database.EnsureCreated();
                context.Database.Migrate();

                seeder(context, serviceProvider);

                logger.LogInformation($"Migrated database associated with context {typeof(TContext).Name}");
            }
            catch (Exception ex)
            {
                logger.LogError(ex,
                    $"An error occurred while migrating the database used on context {typeof(TContext).Name}");
            }

            return serviceProvider;
        }
    }
}
