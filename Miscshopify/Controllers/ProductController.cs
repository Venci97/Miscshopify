using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Miscshopify.Core.Contracts;

namespace Miscshopify.Controllers
{
    [AllowAnonymous]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetProductsByCategory(Guid id, decimal? minPrice, decimal? maxPrice)
        {
            var products = await _productService.GetProductsByCategory(id);

            var allProducts = products.ToList();

            string categoryName = "Products";
            ViewBag.CategoryName = categoryName;

            if (minPrice.HasValue && minPrice > 0)
            {
                products = products.Where(p => p.Price >= minPrice.Value);
                ViewBag.CategoryName = "Filtered Products";
            }

            if (maxPrice.HasValue && maxPrice > 0)
            {
                products = products.Where(p => p.Price <= maxPrice.Value);
                ViewBag.CategoryName = "Filtered Products";
            }

            if (minPrice.HasValue && maxPrice.HasValue && minPrice > 0 && maxPrice > 0)
            {
                products = allProducts.Where(p => p.Price >= minPrice.Value && p.Price <= maxPrice.Value);
                ViewBag.CategoryName = "Filtered Products";
            }

            return View(products);
        }

        public async Task<IActionResult> ProductDetails(Guid id)
        {
            var product = await _productService.ProductDetails(id);
            return View(product);
        }
    }
}