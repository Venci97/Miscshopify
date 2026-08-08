using System.ComponentModel.DataAnnotations;

namespace Miscshopify.Infrastructure.Data.Models
{
    public class SiteSettings
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(100)]
        public string? SiteName { get; set; } = "Miscshopify";

        [StringLength(500)]
        public string? SiteDescription { get; set; } = "Your Modern Shopping Destination";

        [StringLength(100)]
        public string? ContactEmail { get; set; } = "info@miscshopify.com";

        [StringLength(20)]
        public string? ContactPhone { get; set; } = "+1-555-0123";

        public bool ShowMaintenanceMessage { get; set; } = false;

        [StringLength(1000)]
        public string? MaintenanceMessage { get; set; } = "Site will be down for maintenance on...";

        public DateTime? MaintenanceStart { get; set; }
        public DateTime? MaintenanceEnd { get; set; }

        [StringLength(500)]
        public string? HeroImagePath { get; set; } = "uploads/site/hero-default.jpg";

        [StringLength(200)]
        public string? HeroTitle { get; set; } = "Welcome to Miscshopify";

        [StringLength(500)]
        public string? HeroSubtitle { get; set; } = "Discover everything you need in one place";

        [StringLength(4000)]
        public string? PrivacyPolicy { get; set; } = "Your privacy is important to us...";

        [StringLength(4000)]
        public string? TermsAndConditions { get; set; } = "By using our site, you agree to...";

        [StringLength(4000)]
        public string? ReturnPolicy { get; set; } = "You can return products within 30 days...";

        [StringLength(4000)]
        public string? ShippingInformation { get; set; } = "Free shipping on orders over $50...";

        [StringLength(4000)]
        public string? WarrantyInformation { get; set; } = "All products come with 1-year warranty...";

        [StringLength(200)]
        public string? FacebookUrl { get; set; }

        [StringLength(200)]
        public string? InstagramUrl { get; set; }

        [StringLength(200)]
        public string? TwitterUrl { get; set; }

        [StringLength(200)]
        public string? TikTokUrl { get; set; }

        public bool ShowOutOfStockProducts { get; set; } = true;
        public bool AllowPurchasingOutOfStock { get; set; } = false;
        public int LowStockThreshold { get; set; } = 5;

        [StringLength(500)]
        public string? MetaKeywords { get; set; }

        [StringLength(500)]
        public string? MetaDescription { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}