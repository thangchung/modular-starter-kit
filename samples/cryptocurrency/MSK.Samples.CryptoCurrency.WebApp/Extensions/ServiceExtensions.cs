using System;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MSK.Application.Module.Data;
using MSK.Application.Module.Data.Extensions;
using MSK.Core.Module.Entity;
using MSK.Core.Module.Mvc.Extensions;
using MSK.Support.Module.Swagger.Extensions;

namespace MSK.Samples.CryptoCurrency.WebApp.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCryptoCurrency(this IServiceCollection services)
        {
            services.AddDataApplicationModule();

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
                    "MSK.Samples.CryptoCurrency.Migrator"); // TODO: move to settings
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

        public static IApplicationBuilder UseCryptoCurrency(this IApplicationBuilder app, Action<IRouteBuilder> preRouteAction)
        {
            var env = app.ApplicationServices.GetService<IHostingEnvironment>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            // make the authentication working
            app.UseAuthentication();
            app.UseIdentityServer();

            app.UseCors("CorsPolicy");

            app.UseMvc(routes =>
            {
                preRouteAction(routes);

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseMySwagger();

            // https://gist.github.com/int128/e0cdec598c5b3db728ff35758abdbafd
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    // spa.UseReactDevelopmentServer(npmScript: "watch");
                }
            });

            // TODO: consider moving this up
            app.UseModules();

            return app;
        }
    }
}
