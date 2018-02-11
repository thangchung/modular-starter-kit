using System.Collections.Generic;
using MSK.Core.Module.Entity;

namespace MSK.Samples.BiMonetary.Module.Social.Models
{
    public class Link : EntityBase
    {
        public Link()
        {
            Comments = new HashSet<Comment>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Uri { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
