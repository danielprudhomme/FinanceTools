using System;
using System.IO;
using System.Threading.Tasks;

namespace FinanceTools.Core.Contracts.Services
{
    public interface IImportMarketPriceService
    {
        Task ImportFromYahooFinanceCsv(Guid assetId, Stream fileStream);
    }
}
