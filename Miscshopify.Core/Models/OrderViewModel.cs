using Microsoft.EntityFrameworkCore.Metadata;
using Miscshopify.Infrastructure.Data.Models;
using Miscshopify.Infrastructure.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
