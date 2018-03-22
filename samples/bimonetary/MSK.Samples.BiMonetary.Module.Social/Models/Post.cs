using System.Collections.Generic;
using MSK.Core.Module.Domain;

namespace MSK.Samples.BiMonetary.Module.Social.Models
{
    public class Post : EntityBase
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public string Body { get; set; }
        public AuthorId Author { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
