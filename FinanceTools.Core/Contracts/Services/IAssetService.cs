using FinanceTools.Core.Models;
using System;
using System.Threading.Tasks;

namespace FinanceTools.Core.Contracts.Services
{
    public interface IAssetService
    {
        Task<Guid> Insert(InsertAssetModel model);
        Task Edit(EditAssetModel model);
    }
}
