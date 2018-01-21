using System.Collections.Generic;

namespace MSK.Core.Module.Mvc.Extensions
{
    public interface IExtensionManager
    {
        ExtensionInfo GetExtension(string extensionId);
        IEnumerable<ExtensionEntry> GetExtensions();
    }
}