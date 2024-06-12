using Miscshopify.Infrastructure.Data.Models;
using Miscshopify.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Miscshopify.Core.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }

        public string CustomerId { get; set; }

        public OrderStatusEnum Status { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public string CustomerCity { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerPostCode { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public PaymentMethodEnum PaymentMethod { get; set; }

        [Display(Name = "Payment Method")]
        public string PaymentMethodDisplayName
        {
            get
            {
                switch (PaymentMethod)
                {
                    case PaymentMethodEnum.Card:
                        return "Card";
                    case PaymentMethodEnum.CashOnDelivery:
                        return "Cash on Delivery";
                    default:
                        return PaymentMethod.ToString(); // fallback to enum value
                }
            }
        }

        [Display(Name = "Payment Method")]
        public string OrderStatusDisplayName
        {
            get
            {
                switch (Status)
                {
                    case OrderStatusEnum.Pending:
                        return "Pending";
                    case OrderStatusEnum.OnTheWay:
                        return "On the way";
                    case OrderStatusEnum.Completed:
                        return "Completed";
                    default:
                        return Status.ToString(); // fallback to enum value
                }
            }
        }
    }
}
