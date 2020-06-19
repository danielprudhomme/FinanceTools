using FinanceTools.Core.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FinanceTools.Core.Contracts.Services
{
    public interface IImportMarketPriceService
    {
        Task ImportFromYahooFinanceCsv(InsertAssetModel model, Stream fileStream);
        Task ImportFromYahooFinanceCsv(Guid assetId, Stream fileStream);
    }
}
