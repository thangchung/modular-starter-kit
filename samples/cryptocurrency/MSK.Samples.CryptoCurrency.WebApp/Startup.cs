using System;
using AspNetCore.RouteAnalyzer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace MSK.Samples.CryptoCurrency.WebApp
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services
                // .AddSqlServerConfiguration()
                .AddCryptoCurrency()
                .AddRouteAnalyzer()
                .BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCryptoCurrency(preRouteAction: routes => {
                routes.MapRouteAnalyzer("/routes");
            });
        }
    }
}