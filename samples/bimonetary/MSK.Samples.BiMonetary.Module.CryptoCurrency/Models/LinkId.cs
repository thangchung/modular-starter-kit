using System;
using MSK.Core.Module.Domain;

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
