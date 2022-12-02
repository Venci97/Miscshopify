using Microsoft.AspNetCore.Mvc;
using Miscshopify.Core.Contracts;
using Miscshopify.Core.Services;

namespace Miscshopify.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AllCategories()
        {
            var category = await categoryService.GetCategories();

            return View(category);
        }
    }
}
