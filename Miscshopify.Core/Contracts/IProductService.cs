using Miscshopify.Core.Models;
using Miscshopify.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscshopify.Core.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetProducts();
        Task Add(ProductViewModel model);
        Task<ProductViewModel> Edit(Guid id);
        Task<bool> UpdateProductDetails(ProductViewModel model);
        Task<IEnumerable<ProductViewModel>> GetProductsByCategory(Guid Id);
        Task<ProductViewModel> ProductDetails(Guid id);
        Task<Product> GetProductById(Guid id);
        void RemoveProduct(Guid productId);
    }
}
