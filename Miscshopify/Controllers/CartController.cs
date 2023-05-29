using Microsoft.AspNetCore.Mvc;
using Miscshopify.Core.Contracts;
using System.Security.Claims;

namespace Miscshopify.Controllers
{
    public class CartController : BaseController
    {
        private readonly ICartService cartService;

        public CartController(ICartService _cartService)
        {
            cartService = _cartService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userCart = await cartService.GetCartItems(userId);

            decimal totalPrice = 0.0m;
            foreach (var item in userCart)
            {
                totalPrice += item.Price;
            }

            int quantity = 0;
			foreach (var item in userCart)
			{
				quantity += item.Quantity;
			}

			ViewBag.TotalPrice = totalPrice;
            ViewBag.TotalQuantity = quantity;

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
            cartService.RemoveFromCart(Id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Checkout()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userCart = await cartService.GetCartItems(userId);

			decimal totalPrice = 0.0m;
			foreach (var item in userCart)
			{
				totalPrice += item.Price;
			}

			ViewBag.TotalPrice = totalPrice;
			ViewBag.TotalQuantity = userCart.Count();

			return View(userCart);
        }
    }
}