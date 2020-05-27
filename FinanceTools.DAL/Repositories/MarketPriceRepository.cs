using Dapper;
using FinanceTools.Core.Contracts.Repositories;
using FinanceTools.Core.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FinanceTools.DAL.Repositories
{
    public class MarketPriceRepository : BaseRepository, IMarketPriceRepository
    {
        public MarketPriceRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task InsertMany(IEnumerable<MarketPrice> marketPrices)
        {
            DataTable tvp = new DataTable();
            tvp.Columns.Add(new DataColumn("AssetId", typeof(Guid)));
            tvp.Columns.Add(new DataColumn("Date", typeof(DateTime)));
            tvp.Columns.Add(new DataColumn("Price", typeof(decimal)));

            foreach(var marketPrice in marketPrices)
            {
                DataRow row = tvp.NewRow();
                row["AssetId"] = marketPrice.AssetId;
                row["Date"] = marketPrice.Date;
                row["Price"] = marketPrice.Price;
                tvp.Rows.Add(row);
            }

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@marketPriceList", tvp.AsTableValuedParameter("[dbo].[InsertManyMarketPrices_MarketPriceList_Parameter]"));

            await Execute("[dbo].[InsertManyMarketPrices]", queryParameters);
        }

        public async Task<IEnumerable<MarketPrice>> Get(Guid assetId, DateTime startDate, DateTime endDate)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@AssetId", assetId);
            queryParameters.Add("@StartDate", startDate);
            queryParameters.Add("@EndDate", endDate);

            var marketPrices = await Query<MarketPrice>("[dbo].[GetMarketPrices]", queryParameters);

            return marketPrices;
        }
    }
}
