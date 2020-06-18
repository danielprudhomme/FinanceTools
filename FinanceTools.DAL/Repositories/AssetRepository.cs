using Dapper;
using FinanceTools.Core.Contracts.Repositories;
using FinanceTools.Core.Models;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace FinanceTools.DAL.Repositories
{
    public class AssetRepository : BaseRepository, IAssetRepository
    {
        public AssetRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task Insert(Asset asset)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", asset.Id);
            queryParameters.Add("@Isin", asset.Isin);
            queryParameters.Add("@Class", asset.Class);
            queryParameters.Add("@Symbol", asset.Symbol);
            queryParameters.Add("@Label", asset.Label);
            queryParameters.Add("@Currency", asset.Currency);

            await Execute("[dbo].[InsertAsset]", queryParameters);
        }

        public async Task Edit(Asset asset)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", asset.Id);
            queryParameters.Add("@Isin", asset.Isin);
            queryParameters.Add("@Class", asset.Class);
            queryParameters.Add("@Symbol", asset.Symbol);
            queryParameters.Add("@Label", asset.Label);
            queryParameters.Add("@Currency", asset.Currency);

            await Execute("[dbo].[EditAsset]", queryParameters);
        }
    }
}
