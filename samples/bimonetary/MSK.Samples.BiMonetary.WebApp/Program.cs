using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MSK.Application.Module.Migration.Extensions;

namespace MSK.Samples.BiMonetary.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
                .RegisterDbContexts()
                .Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((hostContext, options) =>
                {
                    options.Sources.Clear();
                    options.AddJsonFile("appsettings.json", true, true);
                    options.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", true);
                    if (hostContext.HostingEnvironment.IsDevelopment())
                    {
                        options.AddUserSecrets<Startup>();
                    }
                    options.AddEnvironmentVariables();
                })
                .Build();
        }
    }
}