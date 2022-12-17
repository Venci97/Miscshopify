using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscshopify.Core.Models
{
    public class OrderItemViewModel
    {
        public Guid ProductId { get; set; }

        public Guid OrderId { get; set; }

        public string ProductName { get; set; }

        public string CustomerId { get; set; }

        public int Quantity { get; set; }

        public string ImagePath { get; set; }

        public decimal Price { get; set; }
    }
}
