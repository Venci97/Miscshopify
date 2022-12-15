using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscshopify.Infrastructure.Data.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public string CustomerId { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
