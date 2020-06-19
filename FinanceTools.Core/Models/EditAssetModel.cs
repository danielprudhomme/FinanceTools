using FinanceTools.Core.Enums;
using System;

namespace FinanceTools.Core.Models
{
    public class EditAssetModel
    {
        public Guid Id { get; set; }
        public string Isin { get; set; }
        public AssetClass Class { get; set; }
        public string Label { get; set; }
        public Currency Currency { get; set; }
    }
}
