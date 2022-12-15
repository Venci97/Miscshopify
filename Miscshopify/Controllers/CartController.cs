using Microsoft.AspNetCore.Mvc;
using Miscshopify.Core.Contracts;
using Miscshopify.Infrastructure.Data.Models;
using Miscshopify.Infrastructure.Data.Repositories;
using System.Security.Claims;

namespace Miscshopify.Controllers
{
    public class CartController : BaseController
    {
        private readonly IAppDbRepository repo;
        private readonly ICartService cartService;

        public CartController(IAppDbRepository _repo, ICartService _cartService)
        {
            repo = _repo;
            cartService = _cartService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userCart = await cartService.GetCartItems(userId);

            return View(userCart);
        }

        public IActionResult AddToCart(Guid Id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            cartService.AddToCart(Id, userId);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(Guid Id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cart = repo.All<Cart>()
                .First(c => c.CustomerId == userId);

            cartService.RemoveFromCart(Id, userId);

            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            cartService.Checkout(userId);

            return RedirectToAction("Index");
        }
    }
}