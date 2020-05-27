using FinanceTools.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceTools.Core.Contracts.Services
{
    public interface IMarketPriceService
    {
        Task<IEnumerable<MarketPrice>> Get(Guid assetId, DateTime startDate, DateTime endDate);
    }
}
