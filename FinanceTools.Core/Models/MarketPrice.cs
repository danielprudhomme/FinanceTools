using System;

namespace FinanceTools.Core.Models
{
    public class MarketPrice
    {
        public Guid AssetId { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
    }
}
