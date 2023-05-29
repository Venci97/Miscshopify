namespace Miscshopify.Core.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public string? ImagePath { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }
    }
}
