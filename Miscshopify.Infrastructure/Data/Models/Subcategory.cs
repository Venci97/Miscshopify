using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscshopify.Infrastructure.Data.Models
{
    public class Subcategory
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Sub Category Name")]
        public string Name { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public IList<Product> Products { get; set; } = new List<Product>();

    }
}
