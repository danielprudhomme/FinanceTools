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
        private readonly IAssetService _assetService;

        public ImportMarketPriceService(IMarketPriceRepository marketPriceRepository, IAssetService assetService)
        {
            _marketPriceRepository = marketPriceRepository;
            _assetService = assetService;
        }

        public async Task ImportFromYahooFinanceCsv(InsertAssetModel model, Stream fileStream)
        {
            var assetId = await _assetService.Insert(model);

            var marketPrices = CsvParserProvider.YahooFinanceCsvParser
               .ReadFromStream(fileStream, Encoding.ASCII)
               .Select(x => SetIdToMarketPrice(assetId, x.Result))
               .ToList();

            await _marketPriceRepository.InsertMany(marketPrices);
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
