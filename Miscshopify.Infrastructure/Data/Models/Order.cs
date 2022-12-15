using Miscshopify.Infrastructure.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscshopify.Infrastructure.Data.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; } = new Guid();

        public OrderStatusEnum Status { get; set; } = OrderStatusEnum.Pending;

        public virtual List<CartItem> Items { get; set; }

        //public Guid CartId { get; set; }

        //public Cart Cart { get; set; }
    }
}
