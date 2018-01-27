using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MSK.Application.Module.Data;
using MSK.Core.Module.Entity.Identity;
using MSK.Core.Module.Utils;
using MSK.Core.Module.Utils.Helpers;

namespace MSK.Application.Module.Migration.Seeders
{
    public class IdentitySeeder : SeedDataBase<ApplicationDbContext>
    {
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher = new PasswordHasher<ApplicationUser>();
        private readonly ILogger<IdentitySeeder> _logger;

        public IdentitySeeder(IConfiguration configuration) 
            : base(configuration)
        {
        }

        public override async Task SeedAsync(ApplicationDbContext context)
        {
            Guard.NotNull(Configuration);

            try
            {
                if (!context.Users.Any())
                {
                    await context.Users.AddRangeAsync(GetDefaultUser());
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
        }

        private IEnumerable<ApplicationUser> GetDefaultUser()
        {
            var user = new ApplicationUser()
            {
                Id = IdHelper.GenerateId("0fd266b3-4376-4fa3-9a35-aabe1d08043e"),
                Email = "demouser@nomail.com",
                LastName = "DemoLastName",
                FirstName = "DemoUser",
                PhoneNumber = "1234567890",
                UserName = "demouser@nomail.com",
                NormalizedEmail = "DEMOUSER@NOMAIL.COM",
                NormalizedUserName = "DEMOUSER@NOMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, "P@ssw0rd");

            return new List<ApplicationUser>()
            {
                user
            };
        }
    }
}
