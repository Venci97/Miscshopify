﻿namespace Miscshopify.Infrastructure.Data.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public string CustomerId { get; set; }

        //public virtual ApplicationUser User { get; set; }

        public virtual List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
