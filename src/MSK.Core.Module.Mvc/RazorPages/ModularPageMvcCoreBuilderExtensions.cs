using Microsoft.Extensions.DependencyInjection;

namespace MSK.Core.Module.Mvc.RazorPages
{
    public static class ModularPageMvcCoreBuilderExtensions
    {
        public static IMvcBuilder AddModularRazorPages(this IMvcBuilder builder)
        {
            builder.AddRazorPagesOptions(options =>
            {
                options.RootDirectory = "/";
                options.Conventions.Add(new DefaultModularPageRouteModelConvention());
            });

            return builder;
        }
    }
}
