using System.ComponentModel.DataAnnotations;

namespace Miscshopify.Infrastructure.Data.Models
{
    public class CartItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ProductID { get; set; }

        [Required]
        [StringLength(200)]
        public string ProductName { get; set; }

        [Required]
        public string CustomerId { get; set; }

        public int Quantity { get; set; }

        public string ImagePath { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
