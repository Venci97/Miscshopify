using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Miscshopify.Core.Contracts;

namespace Miscshopify.Controllers
{
    [AllowAnonymous]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetMainCategories();
            return View(categories);
        }

        public async Task<IActionResult> Subcategories(Guid id)
        {
            var subcategories = await categoryService.GetSubcategories(id);
            var parentCategory = await categoryService.GetCategoryById(id);

            ViewBag.ParentCategoryName = parentCategory?.Name;
            ViewBag.ParentCategoryId = id;

            return View(subcategories);
        }
    }
}
