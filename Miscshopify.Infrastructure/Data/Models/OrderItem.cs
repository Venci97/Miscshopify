using System.ComponentModel.DataAnnotations;

namespace Miscshopify.Infrastructure.Data.Models
{
    public class OrderItem
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Guid OrderId { get; set; }

        [Required]
        [StringLength(150)]
        public string ProductName { get; set; }

        [Required]
        public string CustomerId { get; set; }

        public int Quantity { get; set; }

        public string ImagePath { get; set; }

        public decimal Price { get; set; }

        public virtual Order Order { get; set; }
    }
}
