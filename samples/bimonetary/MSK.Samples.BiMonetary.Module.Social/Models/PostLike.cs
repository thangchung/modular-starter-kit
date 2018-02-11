using MSK.Core.Module.Entity;

namespace MSK.Samples.BiMonetary.Module.Social.Models
{
    public class PostLike : EntityBase
    {
        public Post Post { get; set; }
        public UserId User { get; set; }
    }
}
