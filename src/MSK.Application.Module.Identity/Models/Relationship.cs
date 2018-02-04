using System;
using System.Collections.Generic;
using MSK.Core.Module.Entity;
using MSK.Core.Module.Entity.Identity;

namespace MSK.Application.Module.Identity.Models
{
    public class Relationship : IEntity
    {
        public Relationship()
        {
            Followers = new HashSet<ApplicationUser>();
            Followees = new HashSet<ApplicationUser>();
        }

        public Guid Id { get; set; }
        public ICollection<ApplicationUser> Followers { get; set; }
        public ICollection<ApplicationUser> Followees { get; set; }
    }
}