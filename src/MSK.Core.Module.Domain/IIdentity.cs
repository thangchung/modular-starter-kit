using System;

namespace MSK.Core.Module.Domain
{
    public interface IIdentity
    {
        Guid Id { get; }
    }
}