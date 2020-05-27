using System;
using System.Threading.Tasks;
using FinanceTools.Core.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
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
        public async Task ImportYahooFinanceCsv(Guid assetId, IFormFile file)
        {
            using (var fileStream = file.OpenReadStream())
            {
                await _importMarketPriceService.ImportFromYahooFinanceCsv(assetId, fileStream);
            }
        }
    }
}