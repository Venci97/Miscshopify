using System.Collections.Generic;

namespace Miscshopify.Core.Models
{
    public class SearchViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}