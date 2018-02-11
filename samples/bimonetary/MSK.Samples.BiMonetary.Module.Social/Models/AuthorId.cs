using System;
using MSK.Core.Module.Entity;

namespace MSK.Samples.BiMonetary.Module.Social.Models
{
    public class AuthorId : IdentityBase
    {
        private AuthorId()
        {
        }

        public AuthorId(Guid authorId) : base(authorId)
        {
        }
    }
}
