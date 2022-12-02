using Microsoft.AspNetCore.Mvc;

namespace Miscshopify.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
