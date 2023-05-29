using Microsoft.AspNetCore.Mvc;
using Miscshopify.Common.Constants;
using Miscshopify.Core.Contracts;
using Miscshopify.Core.Models;

namespace Miscshopify.Areas.Admin.Controllers
{
    public class CategoryController : AdminBaseController
    {
        private readonly ILogger<CategoryController> logger;
        private readonly ICategoryService categoryService;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public CategoryController(ILogger<CategoryController> _logger, ICategoryService _categoryService, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment)
        {
            logger = _logger;
            categoryService = _categoryService;
            hostingEnvironment = _hostingEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var category = await categoryService.GetCategories();

            return View(category);
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

            string uploadPath = "uploads/categoryImg/";

            var files = HttpContext.Request.Form.Files;

            foreach (var file in files)
            {
                if (file != null && file.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                    var uploadPathWithfileName = Path.Combine(uploadPath, fileName);

                    var uploadAbsolutePath = Path.Combine(hostingEnvironment.WebRootPath, uploadPathWithfileName);

                    using (var fileStream = new FileStream(uploadAbsolutePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        model.ImagePath = uploadPathWithfileName;
                    }
                }
            }

            if (model.ImagePath == null)
            {
                model.ImagePath = "uploads/categoryImg/NoImage.jpg";
            }
            await categoryService.Add(model);

            return RedirectToAction(nameof(Index));
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

        public IActionResult RemoveCategoryWithProducts(Guid Id)
        {
            categoryService.RemoveCategoryWithProducts(Id);

            return RedirectToAction("Index");
        }
    }
}
