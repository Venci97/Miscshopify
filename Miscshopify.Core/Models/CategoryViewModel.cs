using System.ComponentModel.DataAnnotations;

namespace Miscshopify.Core.Models
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }

        public string? ImagePath { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public int ProductsCount { get; set; }

        public Guid? ParentId { get; set; }
        public string? ParentName { get; set; }
        public List<CategoryViewModel>? Children { get; set; }

        public List<CategoryViewModel>? AvailableParentCategories { get; set; }
    }
}