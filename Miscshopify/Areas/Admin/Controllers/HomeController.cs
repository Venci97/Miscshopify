using Microsoft.AspNetCore.Mvc;

namespace Miscshopify.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
