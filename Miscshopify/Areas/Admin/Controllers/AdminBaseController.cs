using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Miscshopify.Common.Constants;

namespace Miscshopify.Areas.Admin.Controllers
{
    [Authorize(Roles = GlobalConstants.UserRoles.Administrator)]
    [Area("Admin")]
    public class AdminBaseController : Controller
    {
    
    }
}
