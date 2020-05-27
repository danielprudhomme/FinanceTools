using AutoMapper;
using FinanceTools.Core.Contracts.Repositories;
using FinanceTools.Core.Contracts.Services;
using FinanceTools.Core.Models;
using FinanceTools.Core.Services;
using FinanceTools.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceTools.DI
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureFinanceTools(this IServiceCollection services)
        {
            // Mapper
            services.AddAutoMapper(typeof(ModelProfile));

            // Repositories
            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddScoped<IMarketPriceRepository, MarketPriceRepository>();

            // Services
            services.AddScoped<IAssetService, AssetService>();
            services.AddScoped<IImportMarketPriceService, ImportMarketPriceService>();
            services.AddScoped<IMarketPriceService, MarketPriceService>();
        }
    }
}
