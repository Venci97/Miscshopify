using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Miscshopify.Infrastructure.Data;

namespace Miscshopify.Controllers
{
    [Authorize()]
    public class BaseController : Controller
    {
        
    }
}
