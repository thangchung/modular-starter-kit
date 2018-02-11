using System;
using MSK.Core.Module.Entity;

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
