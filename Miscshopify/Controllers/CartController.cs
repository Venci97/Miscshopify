using Microsoft.AspNetCore.Mvc;
using Miscshopify.Core.Contracts;
using System.Security.Claims;
using System.Threading.Tasks;
using System;

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
                totalPrice += item.Price * item.Quantity;
            }

            int totalQuantity = 0;
            foreach (var item in userCart)
            {
                totalQuantity += item.Quantity;
            }

            ViewBag.TotalPrice = totalPrice;
            ViewBag.TotalQuantity = totalQuantity;

            return View(userCart);
        }

        public IActionResult AddToCart(Guid Id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            cartService.AddToCart(Id, userId).Wait();

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(Guid Id)
        {
            cartService.RemoveFromCart(Id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(Guid id, int quantity)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (quantity < 1)
            {
                return BadRequest("Quantity must be at least 1.");
            }

            await cartService.UpdateCartItemQuantity(id, quantity, userId);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Checkout()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userCart = await cartService.GetCartItems(userId);

            decimal totalPrice = 0.0m;
            foreach (var item in userCart)
            {
                totalPrice += item.Price * item.Quantity;
            }

            int totalQuantity = 0;
            foreach (var item in userCart)
            {
                totalQuantity += item.Quantity;
            }

            ViewBag.TotalPrice = totalPrice;
            ViewBag.TotalQuantity = totalQuantity;

            return View(userCart);
        }
    }
}
