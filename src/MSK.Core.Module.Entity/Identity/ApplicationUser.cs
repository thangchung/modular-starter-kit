using System;
using Microsoft.AspNetCore.Identity;

namespace MSK.Core.Module.Entity.Identity
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
