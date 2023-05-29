namespace Miscshopify.Core.Models
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }

        public string? ImagePath { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        //public List<Product> Products { get; set; };
    }
}