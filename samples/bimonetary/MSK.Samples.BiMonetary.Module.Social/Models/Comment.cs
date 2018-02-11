using MSK.Core.Module.Entity;

namespace MSK.Samples.BiMonetary.Module.Social.Models
{
    public class Comment : EntityBase
    {
        public string Body { get; set; }
        public AuthorId Author { get; set; }
        public Post Post { get; set; }
    }
}
