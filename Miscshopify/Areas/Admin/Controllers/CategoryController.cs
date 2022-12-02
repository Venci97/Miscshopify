using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Miscshopify.Common.Constants;
using Miscshopify.Core.Contracts;
using Miscshopify.Core.Models;
using Miscshopify.Core.Services;
using System.Data;

namespace Miscshopify.Areas.Admin.Controllers
{
    public class CategoryController : AdminBaseController
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

        [HttpGet]
        public IActionResult Add()
        {
            var model = new CategoryViewModel();
            ViewData["Title"] = "Add new category";
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryViewModel model)
        {
            ViewData["Title"] = "Add new category";

            if (!ModelState.IsValid)
            {

                return View(model);
            }

            await categoryService.Add(model);

            return RedirectToAction(nameof(ManageCategories));
        }

		public async Task<IActionResult> ManageCategories()
        {
			var category = await categoryService.GetCategories();

			return View(category);
		}

        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await categoryService.Edit(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await categoryService.UpdateCategoryDetails(model))
            {
                ViewData[GlobalConstants.Messages.Success] = "Successful";
            }
            else
            {
                ViewData[GlobalConstants.Messages.Error] = "Error! Something happen!";
            }

            return View(model);
        }
    }
}
