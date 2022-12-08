using Microsoft.AspNetCore.Mvc;
using Miscshopify.Common.Constants;
using Miscshopify.Core.Contracts;
using Miscshopify.Core.Models;

namespace Miscshopify.Areas.Admin.Controllers
{
    public class ProductController : AdminBaseController
    {
        private readonly ILogger<ProductController> logger;
        private readonly IProductService productService;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public ProductController(ILogger<ProductController> _logger, IProductService _productService, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment)
        {
            logger = _logger;
            productService = _productService;
            hostingEnvironment = _hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add(Guid Id)
        {
            var model = new ProductViewModel();
            TempData["category"] = Id;

            ViewData["Title"] = "Add new product";
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel model)
        {
            ViewData["Title"] = "Add new product";

            var category = TempData["category"];
            model.CategoryId = (Guid)category;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string uploadPath = "uploads/productImg/";

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
           
            await productService.Add(model);

            return RedirectToAction(nameof(ManageProducts));
        }

        public async Task<IActionResult> ManageProducts()
        {
            var product = await productService.GetProducts();

            return View(product);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await productService.Edit(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await productService.UpdateProductDetails(model))
            {
                ViewData[GlobalConstants.Messages.Success] = "Successful";
            }
            else
            {
                ViewData[GlobalConstants.Messages.Error] = "Error! Something happen!";
            }

            return RedirectToAction(nameof(ManageProducts));
        }

        [HttpGet]
        public IActionResult AddProductToCategory()
        {
            var model = new ProductViewModel();
            ViewData["Title"] = "Add new product to this category";
            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddProductToCategory(Guid id, ProductViewModel model)
        //{
        //    ViewData["Title"] = "Add new product";

        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    string uploadPath = "uploads/productImg/";

        //    var files = HttpContext.Request.Form.Files;

        //    foreach (var file in files)
        //    {
        //        if (file != null && file.Length > 0)
        //        {
        //            var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
        //            var uploadPathWithfileName = Path.Combine(uploadPath, fileName);

        //            var uploadAbsolutePath = Path.Combine(hostingEnvironment.WebRootPath, uploadPathWithfileName);

        //            using (var fileStream = new FileStream(uploadAbsolutePath, FileMode.Create))
        //            {
        //                await file.CopyToAsync(fileStream);
        //                model.ImagePath = uploadPathWithfileName;
        //            }
        //        }
        //    }

        //    if (model.ImagePath == null)
        //    {
        //        model.ImagePath = "uploads/categoryImg/NoImage.jpg";
        //    }
        //    await productService.AddProductToCategory(id, model);

        //    return RedirectToAction(nameof(ManageProducts));
        //}
    }
}
