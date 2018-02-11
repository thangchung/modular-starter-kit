using MSK.Core.Module.Entity;

namespace MSK.Samples.BiMonetary.Module.Social.Models
{
    public class TickerLike : EntityBase
    {
        public TickerId Ticker { get; set; }
        public UserId User { get; set; }
    }
}
