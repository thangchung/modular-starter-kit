using System;

namespace MSK.Core.Module.Domain
{
    public interface IDomainEvent
    {
        int EventVersion { get; set; }
        DateTime OccurredOn { get; set; }
    }
}