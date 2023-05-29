using System.ComponentModel.DataAnnotations;

namespace Miscshopify.Infrastructure.Data.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; } = new Guid();

        public string? ImagePath { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public IList<Product> Products { get; set; } = new List<Product>();
    }
}
