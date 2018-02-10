using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using MSK.Core.Module.Mvc.Extensions;
using MSK.Support.Module.Swagger.Extensions;

namespace MSK.Samples.BiMonetary.WebApp.Extensions
{
    public static class ApplicationExtensions
    {
        public static IApplicationBuilder UseBiMonetary(this IApplicationBuilder app, Action<IRouteBuilder> preRouteAction)
        {
            var env = app.ApplicationServices.GetService<IHostingEnvironment>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            // make the authentication working
            app.UseAuthentication();
            app.UseIdentityServer();

            app.UseCors("CorsPolicy");

            app.UseMvc(routes =>
            {
                preRouteAction(routes);

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseMySwagger();

            // https://gist.github.com/int128/e0cdec598c5b3db728ff35758abdbafd
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    // spa.UseReactDevelopmentServer(npmScript: "watch");
                }
            });

            app.UseModules();

            return app;
        }
    }
}
