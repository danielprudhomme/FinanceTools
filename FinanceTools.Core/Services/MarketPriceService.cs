using FinanceTools.Core.Contracts.Repositories;
using FinanceTools.Core.Contracts.Services;
using FinanceTools.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceTools.Core.Services
{
    public class MarketPriceService : IMarketPriceService
    {
        private readonly IMarketPriceRepository _marketPriceRepository;

        public MarketPriceService(IMarketPriceRepository marketPriceRepository)
        {
            _marketPriceRepository = marketPriceRepository;
        }

        public async Task<IEnumerable<MarketPrice>> Get(Guid assetId, DateTime startDate, DateTime endDate)
        {
            return await _marketPriceRepository.Get(assetId, startDate, endDate);   
        }
    }
}
