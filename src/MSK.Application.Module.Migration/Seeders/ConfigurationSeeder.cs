using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using MSK.Core.Module.Utils;

namespace MSK.Application.Module.Migration.Seeders
{
    public class AuthConfigSeeder : SeedDataBase<ConfigurationDbContext>
    {
        public AuthConfigSeeder(IConfiguration configuration) 
            : base(configuration)
        {
        }

        public async override Task SeedAsync(ConfigurationDbContext context)
        {
            Guard.NotNull(Configuration);

            await context.Clients.AddRangeAsync(
                GetClients(Configuration)
                    .Where(x => !context.Clients.Any(y => y.ClientId == x.ClientId))
                    .Select(x => x.ToEntity()));

            await context.IdentityResources.AddRangeAsync(
                GetResources()
                    .Where(x => !context.IdentityResources.Any(y => y.Name == x.Name))
                    .Select(x => x.ToEntity()));

            await context.ApiResources.AddRangeAsync(
                GetApis()
                    .Where(x => !context.ApiResources.Any(y => y.Name == x.Name))
                    .Select(x => x.ToEntity()));

            await context.SaveChangesAsync();
        }

        private IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("Core", "Core"),
            };
        }

        private IEnumerable<IdentityResource> GetResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        private IEnumerable<Client> GetClients(IConfiguration configuration)
        {
            var clientUrls = new Dictionary<string, string>
            {
                {"SpaReactClient", configuration.GetValue<string>("Clients:SpaReactClient")},
                {"WebApi", configuration.GetValue<string>("Clients:WebApi")}
            };

            return new List<Client>()
            {
                new Client
                {
                    ClientId = "1a0e947d-99d7-4c6d-a2f3-a196a7da64a4",
                    ClientName = "React Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris =           { $"{clientUrls["SpaReactClient"]}/callback" },
                    RequireConsent = false,
                    PostLogoutRedirectUris = { $"{clientUrls["SpaReactClient"]}/logout" },
                    AllowedCorsOrigins =     { $"{clientUrls["SpaReactClient"]}" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "Core"
                    }
                },
                new Client
                {
                    ClientId = "5b811d87-75e0-49af-ac1c-1fe7ebd73f60",
                    ClientName = "Core API - Swagger UI",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = { $"{clientUrls["WebApi"]}/swagger/o2c.html" },
                    PostLogoutRedirectUris = { $"{clientUrls["WebApi"]}/swagger/" },

                    AllowedScopes =
                    {
                        "Core"
                    }
                }
            };
        }
    }
}
