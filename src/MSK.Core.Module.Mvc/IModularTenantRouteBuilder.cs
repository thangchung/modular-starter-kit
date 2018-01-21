using Microsoft.AspNetCore.Routing;

namespace MSK.Core.Module.Mvc
{
    public interface IModularTenantRouteBuilder
    {
        IRouteBuilder Build();
        void Configure(IRouteBuilder builder);
    }
}
