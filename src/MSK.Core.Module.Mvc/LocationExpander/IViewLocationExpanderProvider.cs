using Microsoft.AspNetCore.Mvc.Razor;

namespace MSK.Core.Module.Mvc.LocationExpander
{
    public interface IViewLocationExpanderProvider : IViewLocationExpander
    {
        int Priority { get; }
    }
}
