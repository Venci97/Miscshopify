using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Miscshopify.Common.Constants;

namespace Miscshopify.Controllers
{
    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(RoleManager<IdentityRole> _roleManager)
        {
            this.roleManager = _roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreateRole()
        {
            await roleManager.CreateAsync(new IdentityRole()
            {
                Name = "User"
            });

            return Ok();
        }
    }
}
