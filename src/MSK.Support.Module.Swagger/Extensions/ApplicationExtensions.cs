using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace MSK.Support.Module.Swagger.Extensions
{
    public static class ApplicationExtensions
    {
        public static IApplicationBuilder UseMySwagger(this IApplicationBuilder app)
        {
            var config = app.ApplicationServices.GetService(typeof(IConfiguration)) as IConfiguration;
            var uri = config.GetSection("ClientUris")["WebApiAndAuthUri"];

            return app
                .UseSwagger(c =>
                {
                    c.RouteTemplate = "ui-swagger/{documentName}/swagger.json";
                })
                .UseSwaggerUI(
                    c =>
                    {
                        c.SwaggerEndpoint($"{uri}/ui-swagger/v1/swagger.json", "APIs");
                        c.RoutePrefix = "ui-swagger";
                        c.ConfigureOAuth2("5b811d87-75e0-49af-ac1c-1fe7ebd73f60", "", "", "Swagger UI");
                    });
        }
    }
}
