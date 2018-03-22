using System;
using MSK.Core.Module.Domain;

namespace MSK.Samples.BiMonetary.Module.Social.Models
{
    public class UserId : IdentityBase
    {
        private UserId()
        {
        }

        public UserId(Guid authorId) : base(authorId)
        {
        }
    }
}
