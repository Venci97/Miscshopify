namespace Miscshopify.Core.Models
{
    public class CartItemViewModel
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public int Quantity { get; set; }
    }
}
