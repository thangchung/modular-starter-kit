using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MSK.Application.Module.Data;
using MSK.Application.Module.Migration;
using MSK.Core.Module.Utils;
using MSK.Samples.BiMonetary.Module.CryptoCurrency.Models;

namespace MSK.Samples.BiMonetary.Module.CryptoCurrency.Seeders
{
    public class TickerSeeder : SeedDataBase<ApplicationDbContext>
    {
        public TickerSeeder(IConfiguration configuration) 
            : base(configuration)
        {
        }

        public override async Task SeedAsync(ApplicationDbContext context)
        {
            Guard.NotNull(Configuration);

            try
            {
                if (!context.Set<Ticker>().Any())
                {
                    await context.Set<Ticker>().AddRangeAsync(
                        new Ticker {Name = "BitCoin", Symbol = "BTC", Rank = 1},
                        new Ticker {Name = "Ethereum", Symbol = "ETH", Rank = 2}
                    );
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
