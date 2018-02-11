using MSK.Core.Module.Entity;

namespace MSK.Samples.BiMonetary.Module.Social.Models
{
    public class LinkLike : EntityBase
    {
        public Link Link { get; set; }
        public UserId User { get; set; }
    }
}
