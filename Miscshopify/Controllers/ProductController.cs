using Microsoft.AspNetCore.Mvc;
using Miscshopify.Core.Contracts;

namespace Miscshopify.Controllers
{
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
    }
}
