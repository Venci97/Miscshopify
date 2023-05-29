using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Miscshopify.Controllers
{
    [Authorize()]
    public class BaseController : Controller
    {
        
    }
}
