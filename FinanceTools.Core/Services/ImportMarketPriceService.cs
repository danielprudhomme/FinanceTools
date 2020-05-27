using FinanceTools.Core.Contracts.Repositories;
using FinanceTools.Core.Contracts.Services;
using FinanceTools.Core.Models;
using FinanceTools.Core.Services.CsvParsing;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCsvParser;

namespace FinanceTools.Core.Services
{
    public class ImportMarketPriceService : IImportMarketPriceService
    {
        private readonly IMarketPriceRepository _marketPriceRepository;

        public ImportMarketPriceService(IMarketPriceRepository marketPriceRepository)
        {
            _marketPriceRepository = marketPriceRepository;
        }

        public async Task ImportFromYahooFinanceCsv(Guid assetId, Stream fileStream)
        {
            var marketPrices = CsvParserProvider.YahooFinanceCsvParser
               .ReadFromStream(fileStream, Encoding.ASCII)
               .Select(x => SetIdToMarketPrice(assetId, x.Result))
               .ToList();

            await _marketPriceRepository.InsertMany(marketPrices);
        }

        private MarketPrice SetIdToMarketPrice(Guid assetId, MarketPrice marketPrice)
        {
            marketPrice.AssetId = assetId;
            return marketPrice;
        }
    }
}
