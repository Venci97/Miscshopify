using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Miscshopify.Core.Contracts;

namespace Miscshopify.Controllers
{
    [AllowAnonymous]
    public class ProductController : BaseController
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetProductsByCategory(Guid Id)
        {
            var product = await productService.GetProductsByCategory(Id);

            return View(product);
        }

        public async Task<IActionResult> ProductDetails(Guid Id)
        {
            var product = await productService.ProductDetails(Id);
                
            return View(product);
        }

        public async Task<IActionResult> FilterProducts(decimal minPrice, decimal maxPrice, Guid Id)
        {
            var product = await productService.GetProductsByCategory(Id);
            if (decimal.IsNegative(minPrice) || decimal.IsNegative(maxPrice) || minPrice == 0 || maxPrice == 0)
            {
                return View(product);
            }
            else
            {
                var filteredProduct = product.Where(p => p.Price >= minPrice && p.Price <= maxPrice);
                return View(filteredProduct);
            }

        }

    }
}
