using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Miscshopify.Common.Constants;
using Miscshopify.Core.Contracts;
using Miscshopify.Infrastructure.Data.Models;
using System.Data;

namespace Miscshopify.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<ApplicationUser> userManager;

        private readonly IUserService userService;
        public UserController(RoleManager<IdentityRole> _roleManager, UserManager<ApplicationUser> _userManager, IUserService _userService)
        {
            roleManager = _roleManager;
            userManager = _userManager;
            userService = _userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateRole()
        {
            await roleManager.CreateAsync(new IdentityRole()
            {
                Name = "Administrator"
            });

            return Ok();
        }

        public async Task<IActionResult> ChangeUserRoles()
        {
            var users = await userService.GetUsers();

            return Ok();
        }
    }
}

