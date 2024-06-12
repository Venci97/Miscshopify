using Miscshopify.Infrastructure.Data.Models.Enums;
using Stripe;
using System.ComponentModel.DataAnnotations;

namespace Miscshopify.Infrastructure.Data.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; } = new Guid();

        [Required]
        public string UserId { get; set; }

        [Required]
        [StringLength(150)]
        public string CustomerName { get; set; }

        public OrderStatusEnum Status { get; set; } = OrderStatusEnum.Pending;

        public virtual ApplicationUser User { get; set; }

        public virtual List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public PaymentMethodEnum PaymentMethod { get; set; }
    }
}
