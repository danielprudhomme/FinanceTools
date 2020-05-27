using FinanceTools.Core.Models;
using System.Threading.Tasks;

namespace FinanceTools.Core.Contracts.Repositories
{
    public interface IAssetRepository
    {
        Task Insert(Asset asset);
        Task Edit(Asset asset);
    }
}
