using Miscshopify.Infrastructure.Data.Models;

namespace Miscshopify.Core.Contracts
{
    public interface ISettingsService
    {
        Task<SiteSettings> GetSettingsAsync();
        Task UpdateSettingsAsync(SiteSettings settings);
        Task<bool> IsMaintenanceModeActiveAsync();
    }
}