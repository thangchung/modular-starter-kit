using System.Text.Encodings.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MSK.Application.Module.Data;
using MSK.Application.Module.Data.Extensions;
using MSK.Core.Module.Entity;
using MSK.Core.Module.Mvc.Extensions;
using MSK.Support.Module.Swagger.Extensions;

namespace MSK.Samples.BiMonetary.WebApp.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddBiMonetary(this IServiceCollection services)
        {
            services.AddDataModule();

            var serviceProvider = services.BuildServiceProvider();
            var config = serviceProvider.GetService<IConfiguration>();
            var extendOptionsBuilder = serviceProvider.GetService<IExtendDbContextOptionsBuilder>();
            var dbConnectionStringFactory = serviceProvider.GetService<IDatabaseConnectionStringFactory>();

            services.AddSingleton(JavaScriptEncoder.Default);

            services.AddOptions()
                .Configure<PaginationOption>(config.GetSection("Pagination"));

            void optionsBuilderAction(DbContextOptionsBuilder optionsBuilder)
            {
                extendOptionsBuilder.Extend(
                    optionsBuilder, 
                    dbConnectionStringFactory,
                    config.GetSection("Migration")["MigrationAssemblyName"]);
            }

            services.AddDbContext<ApplicationDbContext>(options => optionsBuilderAction(options));

            services.AddScoped<DbContext>(resolver => resolver.GetRequiredService<ApplicationDbContext>());

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddMvcModules();
            services.AddMySwagger();
            // services.AddMyGraphQL();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            return services;
        }
    }
}
