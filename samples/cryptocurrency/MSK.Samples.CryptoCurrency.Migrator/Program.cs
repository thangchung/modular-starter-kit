using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace MSK.Samples.CryptoCurrency.Migrator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args);
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args).Build();
    }
}
