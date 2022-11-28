using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Miscshopify.Infrastructure.Data.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; } = new Guid();

        [Required]
        [StringLength(100)]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool IsActive { get; set; } = true;

        public Guid SubcategoryId { get; set; }

        [ForeignKey(nameof(SubcategoryId))]
        public Subcategory Subcategories { get; set; }
    }
}
