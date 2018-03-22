using System;
using System.Collections.Generic;
using MSK.Core.Module.Domain;

namespace MSK.Samples.BiMonetary.Module.CryptoCurrency.Models
{
    public class Ticker : EntityBase
    {
        public Ticker()
        {
            Posts = new HashSet<PostId>();
            Links = new HashSet<LinkId>();
        }

        public string Name { get; set; }
        public string Symbol { get; set; }
        public int Rank { get; set; }
        public double PriceUsd { get; private set; }
        public double PriceBtc { get; private set; }
        public double Volumn24hUsd { get; private set; }
        public double MarketCapUsd { get; private set; }
        public double AvailableSupply { get; private set; }
        public double TotalSupply { get; private set; }
        public string PercentChange1h { get; private set; }
        public string PercentChange24h { get; private set; }
        public string PercentChange7d { get; private set; }
        public DateTime LastSyncWithService { get; private set; }

        public ICollection<PostId> Posts { get; set; }
        public ICollection<LinkId> Links { get; set; }
    }
}