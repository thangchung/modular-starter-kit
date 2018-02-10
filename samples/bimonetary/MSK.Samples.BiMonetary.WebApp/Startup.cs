using System;
using AspNetCore.RouteAnalyzer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MSK.Samples.BiMonetary.WebApp.Extensions;

namespace MSK.Samples.BiMonetary.WebApp
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services
                .AddBiMonetary()
                .AddRouteAnalyzer()
                .BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseBiMonetary(preRouteAction: routes => {
                routes.MapRouteAnalyzer("/routes");
            });
        }
    }
}