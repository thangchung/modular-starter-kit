using System;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MSK.Application.Module.Data;
using MSK.Application.Module.Identity.Extensions;
using MSK.Application.Module.Identity.Services;
using MSK.Core.Module.Entity.Identity;
using MSK.Core.Module.Mvc;

namespace MSK.Application.Module.Identity
{
    public class Startup : StartupBase
    {
        public override int Order => 1;

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ILoginService<ApplicationUser>, LoginService>();
            services.AddTransient<IProfileService, IdentityWithAdditionalClaimsProfileService>();

            var serviceProvider = services.BuildServiceProvider();
            var env = serviceProvider.GetService<IHostingEnvironment>();
            var config = serviceProvider.GetService<IConfiguration>();
            var extendOptionsBuilder = serviceProvider.GetService<IExtendDbContextOptionsBuilder>();
            var dbConnectionStringFactory = serviceProvider.GetService<IDatabaseConnectionStringFactory>();

            void optionsBuilderAction(DbContextOptionsBuilder optionsBuilder)
            {
                extendOptionsBuilder.Extend(
                    optionsBuilder, 
                    dbConnectionStringFactory,
                    config.GetSection("Migration")["MigrationAssemblyName"]);
            }

            // Adds DbContexts
            services.AddIdentity<ApplicationUser, ApplicationRole>()
              .AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders();

            // Adds IdentityServer
            var identityServerBuilder = services
                .AddIdentityServer(x =>
                {
                    x.IssuerUri = "null";
                    x.UserInteraction.LoginUrl = "/identity/account/login";
                    x.UserInteraction.ConsentUrl = "/identity/consent/index";
                    x.UserInteraction.ErrorUrl = "/identity/home/error";
                })
                .AddAspNetIdentity<ApplicationUser>()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder => optionsBuilderAction(builder);
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder => optionsBuilderAction(builder);
                })
                .AddProfileService<IdentityWithAdditionalClaimsProfileService>()
                .AddJwtBearerClientAuthentication()
                .AddAppAuthRedirectUriValidator();

            if (env.IsDevelopment())
            {
                identityServerBuilder.AddDeveloperSigningCredential();
            }
            else
            {
                var options = services.BuildServiceProvider().GetService<IConfiguration>().GetSection("Certificate");
                identityServerBuilder.AddCertificateFromFile(options);
            }

            base.ConfigureServices(services);
        }

        public override void Configure(IApplicationBuilder app, IRouteBuilder routes, IServiceProvider serviceProvider)
        {
            // TODO: aPhuong: could we make it load before the MvcCore?
            // app.UseAuthentication();
            // app.UseIdentityServer();
        }
    }
}
