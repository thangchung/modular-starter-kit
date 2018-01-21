using Microsoft.AspNetCore.Builder;
using MSK.Core.Module.Mvc.Middlewares;

namespace MSK.Core.Module.Mvc.Extensions
{
    public static class ModularApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseModules(this IApplicationBuilder app)
        {
            app.UseMiddleware<ModularTenantRouterMiddleware>();
            return app;
        }
    }
}