using System;
using System.Threading.Tasks;
using FinanceTools.Core.Contracts.Services;
using FinanceTools.Core.Enums;
using FinanceTools.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinanceTools.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportMarketPriceController : BaseController<ImportMarketPriceController>
    {
        private readonly IImportMarketPriceService _importMarketPriceService;

        public ImportMarketPriceController(ILogger<ImportMarketPriceController> logger, IImportMarketPriceService importMarketPriceService) : base(logger)
        {
            _importMarketPriceService = importMarketPriceService;
        }

        [HttpPost]
        public async Task ImportYahooFinanceCsv(string isin, AssetClass assetClass, string label, Currency currency, IFormFile file)
        {
            var model = new InsertAssetModel
            {
                Isin = isin,
                Class = assetClass,
                Label = label,
                Currency = currency
            };

            using (var fileStream = file.OpenReadStream())
            {
                await _importMarketPriceService.ImportFromYahooFinanceCsv(model, fileStream);
            }
        }

        [HttpPut]
        public async Task ImportYahooFinanceCsvToExistingAsset(Guid assetId, IFormFile file)
        {
            using (var fileStream = file.OpenReadStream())
            {
                await _importMarketPriceService.ImportFromYahooFinanceCsv(assetId, fileStream);
            }
        }
    }
}