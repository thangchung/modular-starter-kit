using System;
using MSK.Core.Module.Entity;

namespace MSK.Samples.BiMonetary.Module.CryptoCurrency.Models
{
    public class PostId : IdentityBase
    {
        private PostId()
        {
        }

        public PostId(Guid postId) : base(postId)
        {
        }
    }
}
