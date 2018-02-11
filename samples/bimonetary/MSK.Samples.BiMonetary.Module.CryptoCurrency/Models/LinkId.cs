using System;
using MSK.Core.Module.Entity;

namespace MSK.Samples.BiMonetary.Module.CryptoCurrency.Models
{
    public class LinkId : IdentityBase
    {
        private LinkId()
        {
        }

        public LinkId(Guid linkId) : base(linkId)
        {
        }
    }
}
