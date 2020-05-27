using AutoMapper;
using FinanceTools.Core.Contracts.Repositories;
using FinanceTools.Core.Contracts.Services;
using FinanceTools.Core.Models;
using System;
using System.Threading.Tasks;

namespace FinanceTools.Core.Services
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IMapper _mapper;

        public AssetService(IAssetRepository assetRepository, IMapper mapper)
        {
            _assetRepository = assetRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Insert(InsertAssetModel model)
        {
            var asset = _mapper.Map<Asset>(model);
            asset.Id = Guid.NewGuid();

            await _assetRepository.Insert(asset);

            return asset.Id;
        }

        public async Task Edit(EditAssetModel model)
        {
            var asset = _mapper.Map<Asset>(model);

            await _assetRepository.Edit(asset);
        }
    }
}
