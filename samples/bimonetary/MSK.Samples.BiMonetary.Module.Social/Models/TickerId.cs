using System;
using MSK.Core.Module.Domain;

namespace MSK.Samples.BiMonetary.Module.Social.Models
{
    public class TickerId : IdentityBase
    {
        private TickerId()
        {
        }

        public TickerId(Guid authorId) : base(authorId)
        {
        }
    }
}
