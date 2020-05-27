using FinanceTools.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceTools.Core.Contracts.Repositories
{
    public interface IMarketPriceRepository
    {
        Task InsertMany(IEnumerable<MarketPrice> marketPrices);
        Task<IEnumerable<MarketPrice>> Get(Guid assetId, DateTime startDate, DateTime endDate);
    }
}
