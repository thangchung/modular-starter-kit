using System;
using Microsoft.AspNetCore.Identity;

namespace MSK.Core.Module.Domain.Identity
{
    public class ApplicationUser : IdentityUser<Guid>, IEntity
    {
        public string LastName
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }
    }
}
