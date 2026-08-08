using Miscshopify.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Miscshopify.Infrastructure.Data.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string UserId { get; set; }

        [Required]
        [StringLength(150)]
        public string CustomerName { get; set; }

        public OrderStatusEnum Status { get; set; } = OrderStatusEnum.Pending;

        public virtual ApplicationUser User { get; set; }

        public virtual List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public PaymentMethodEnum PaymentMethod { get; set; }

        public bool IsPaid { get; set; } = false;

        public DateTime? PaymentDate { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total amount must be greater than 0")]
        public decimal TotalAmount { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [StringLength(200)]
        public string OrderCustomerAddress { get; set; }

        [StringLength(100)]
        public string OrderCustomerCity { get; set; }

        [StringLength(20)]
        public string OrderCustomerPostCode { get; set; }

        [StringLength(100)]
        public string OrderCustomerEmail { get; set; }

        [StringLength(20)]
        public string OrderCustomerPhoneNumber { get; set; }
    }
}