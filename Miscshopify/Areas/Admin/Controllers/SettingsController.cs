using Microsoft.AspNetCore.Mvc;
using Miscshopify.Core.Contracts;
using Miscshopify.Infrastructure.Data.Models;

namespace Miscshopify.Areas.Admin.Controllers
{
    public class SettingsController : AdminBaseController
    {
        private readonly ISettingsService _settingsService;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public SettingsController(ISettingsService settingsService,
                               Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _settingsService = settingsService;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var settings = await _settingsService.GetSettingsAsync();
            return View(settings);
        }

        [HttpPost]
        public async Task<IActionResult> Index(SiteSettings model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var files = HttpContext.Request.Form.Files;
            if (files.Count > 0)
            {
                var file = files[0];
                if (file != null && file.Length > 0)
                {
                    string uploadPath = "uploads/site/";
                    var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                    var uploadPathWithFileName = Path.Combine(uploadPath, fileName);

                    var uploadAbsolutePath = Path.Combine(_hostingEnvironment.WebRootPath, uploadPathWithFileName);

                    var directory = Path.GetDirectoryName(uploadAbsolutePath);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    using (var fileStream = new FileStream(uploadAbsolutePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        model.HeroImagePath = uploadPathWithFileName;
                    }
                }
            }

            await _settingsService.UpdateSettingsAsync(model);

            TempData["SuccessMessage"] = "Settings updated successfully!";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ToggleMaintenance(bool enable)
        {
            var settings = await _settingsService.GetSettingsAsync();
            settings.ShowMaintenanceMessage = enable;
            await _settingsService.UpdateSettingsAsync(settings);

            return Json(new { success = true, message = $"Maintenance mode {(enable ? "enabled" : "disabled")}" });
        }
    }
}