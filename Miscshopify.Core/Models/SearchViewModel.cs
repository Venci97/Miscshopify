using Miscshopify.Infrastructure.Data.Models;

namespace Miscshopify.Core.Models
{
    public class SearchViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}
