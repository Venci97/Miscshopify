using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Miscshopify.Infrastructure.Data;

namespace Miscshopify.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly MiscshopifyContext _context;

        public SidebarViewComponent(MiscshopifyContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}