using Microsoft.EntityFrameworkCore;
using Miscshopify.Core.Contracts;
using Miscshopify.Infrastructure.Data;
using Miscshopify.Infrastructure.Data.Models;

namespace Miscshopify.Core.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly MiscshopifyContext _repo;

        public SettingsService(MiscshopifyContext repo)
        {
            _repo = repo;
        }

        public async Task<SiteSettings> GetSettingsAsync()
        {
            var settings = await _repo.SiteSettings.FirstOrDefaultAsync();
            if (settings == null)
            {
                settings = new SiteSettings();
                await _repo.SiteSettings.AddAsync(settings);
                await _repo.SaveChangesAsync();
            }
            return settings;
        }

        public async Task UpdateSettingsAsync(SiteSettings settings)
        {
            var existingSettings = await _repo.SiteSettings.FirstOrDefaultAsync();
            if (existingSettings != null)
            {
                existingSettings.SiteName = settings.SiteName;
                existingSettings.SiteDescription = settings.SiteDescription;
                existingSettings.ContactEmail = settings.ContactEmail;
                existingSettings.ContactPhone = settings.ContactPhone;
                existingSettings.ShowMaintenanceMessage = settings.ShowMaintenanceMessage;
                existingSettings.MaintenanceMessage = settings.MaintenanceMessage;
                existingSettings.MaintenanceStart = settings.MaintenanceStart;
                existingSettings.MaintenanceEnd = settings.MaintenanceEnd;
                existingSettings.HeroImagePath = settings.HeroImagePath;
                existingSettings.HeroTitle = settings.HeroTitle;
                existingSettings.HeroSubtitle = settings.HeroSubtitle;
                existingSettings.PrivacyPolicy = settings.PrivacyPolicy;
                existingSettings.TermsAndConditions = settings.TermsAndConditions;
                existingSettings.ReturnPolicy = settings.ReturnPolicy;
                existingSettings.ShippingInformation = settings.ShippingInformation;
                existingSettings.WarrantyInformation = settings.WarrantyInformation;
                existingSettings.FacebookUrl = settings.FacebookUrl;
                existingSettings.InstagramUrl = settings.InstagramUrl;
                existingSettings.TwitterUrl = settings.TwitterUrl;
                existingSettings.ShowOutOfStockProducts = settings.ShowOutOfStockProducts;
                existingSettings.AllowPurchasingOutOfStock = settings.AllowPurchasingOutOfStock;
                existingSettings.LowStockThreshold = settings.LowStockThreshold;
                existingSettings.MetaKeywords = settings.MetaKeywords;
                existingSettings.MetaDescription = settings.MetaDescription;
                existingSettings.UpdatedAt = DateTime.UtcNow;

                await _repo.SaveChangesAsync();
            }
            else
            {
                settings.UpdatedAt = DateTime.UtcNow;
                await _repo.SiteSettings.AddAsync(settings);
                await _repo.SaveChangesAsync();
            }
        }

        public async Task<bool> IsMaintenanceModeActiveAsync()
        {
            var settings = await GetSettingsAsync();
            if (!settings.ShowMaintenanceMessage) return false;

            var now = DateTime.UtcNow;
            if (settings.MaintenanceStart.HasValue && settings.MaintenanceEnd.HasValue)
            {
                return now >= settings.MaintenanceStart.Value && now <= settings.MaintenanceEnd.Value;
            }

            return settings.ShowMaintenanceMessage;
        }
    }
}