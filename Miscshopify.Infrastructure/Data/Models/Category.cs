using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Miscshopify.Infrastructure.Data.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; } = new Guid();

        public string ImagePath { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public IList<Product> SubCategories { get; set; } = new List<Product>();
    }
}
