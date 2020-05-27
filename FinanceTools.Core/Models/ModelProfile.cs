using AutoMapper;

namespace FinanceTools.Core.Models
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<InsertAssetModel, Asset>();
            CreateMap<EditAssetModel, Asset>();
        }
    }
}
