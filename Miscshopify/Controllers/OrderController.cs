using Microsoft.AspNetCore.Mvc;

namespace Miscshopify.Controllers
{
    public class OrderController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
