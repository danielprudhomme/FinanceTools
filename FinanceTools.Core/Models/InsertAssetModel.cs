﻿using FinanceTools.Core.Enums;

namespace FinanceTools.Core.Models
{
    public class InsertAssetModel
    {
        public string Isin { get; set; }
        public AssetClass Class { get; set; }
        public string Label { get; set; }
        public Currency Currency { get; set; }
    }
}
