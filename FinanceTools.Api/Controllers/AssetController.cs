using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceTools.Core.Contracts.Services;
using FinanceTools.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinanceTools.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : BaseController<AssetController>
    {
        private readonly IAssetService _assetService;
        private readonly IMarketPriceService _marketPriceService;

        public AssetController(
            ILogger<AssetController> logger,
            IAssetService assetService,
            IMarketPriceService marketPriceService) : base(logger)
        {
            _assetService = assetService;
            _marketPriceService = marketPriceService;
        }

        [HttpPost]
        public async Task<Guid> Insert([FromBody] InsertAssetModel model)
        {
            return await _assetService.Insert(model);
        }

        [HttpPut]
        public async Task Edit([FromBody] EditAssetModel model)
        {
            await _assetService.Edit(model);
        }

        [HttpGet("MarketPrices")]
        public async Task<IEnumerable<MarketPrice>> GetMarketPrices(Guid assetId, DateTime startDate, DateTime endDate)
        {
            return await _marketPriceService.Get(assetId, startDate, endDate);
        }
    }
}