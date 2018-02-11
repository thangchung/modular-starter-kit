using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Transports.WebSockets;
using GraphQL.Server.Transports.WebSockets.Events;
using Microsoft.Extensions.DependencyInjection;
using MSK.Samples.BiMonetary.Module.GraphQL.GraphQL;

namespace MSK.Samples.BiMonetary.Module.GraphQL.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddMyGraphQL(this IServiceCollection services)
        {
            services.AddSingleton<IBiMonetary, GraphQL.BiMonetary>();
            services.AddSingleton<BiMonetarySchema>();
            services.AddSingleton<BiMonetaryQuery>();
            services.AddSingleton<BiMonetaryMutation>();
            services.AddSingleton<BiMonetarySubscriptions>();

            // subscriptions
            services.AddSingleton<IEventAggregator, SimpleEventAggregator>();

            services.AddGraphQLHttp();
            services.AddGraphQLWebSocket<BiMonetarySchema>();

            return services;
        }
    }
}