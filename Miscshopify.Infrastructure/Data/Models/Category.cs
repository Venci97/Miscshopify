using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Miscshopify.Infrastructure.Data.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? ImagePath { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public Guid? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public Category? Parent { get; set; }

        public IList<Category> Children { get; set; } = new List<Category>();
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}