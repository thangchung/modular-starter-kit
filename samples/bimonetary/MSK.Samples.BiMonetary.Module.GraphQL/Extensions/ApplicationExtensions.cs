using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Transports.WebSockets;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using MSK.Samples.BiMonetary.Module.GraphQL.GraphQL;

namespace MSK.Samples.BiMonetary.Module.GraphQL.Extensions
{
    public static class ApplicationExtensions
    {
        public static IApplicationBuilder UseMyGraphQL(this IApplicationBuilder app)
        {
            app.UseWebSockets();
            app.UseGraphQLWebSocket<BiMonetarySchema>(new GraphQLWebSocketsOptions());
            app.UseGraphQLHttp<BiMonetarySchema>(new GraphQLHttpOptions());
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions()
            {
                Path = "/ui/playground"
            });
            app.UseGraphiQLServer(new GraphiQLOptions
            {
                GraphiQLPath = "/ui/graphiql",
                GraphQLEndPoint = "/graphql"
            });

            return app;
        }
    }
}