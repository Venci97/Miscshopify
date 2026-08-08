using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Miscshopify.Core.Contracts;
using Miscshopify.Core.Models;
using Miscshopify.Infrastructure.Data.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;

namespace Miscshopify.Controllers
{
    public class CartController : BaseController
    {
        private readonly ICartService cartService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(ICartService _cartService, UserManager<ApplicationUser> userManager)
        {
            cartService = _cartService;
            _userManager = userManager;
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

        public async Task<IActionResult> AddToCart(Guid Id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await cartService.AddToCart(Id, userId);

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

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var cartItems = await cartService.GetCartItems(userId);

            if (cartItems == null || !cartItems.Any())
            {
                TempData["Error"] = "Your cart is empty";
                return RedirectToAction("Index");
            }

            var model = new CheckoutViewModel
            {
                Items = cartItems.ToList(),
                TotalPrice = cartItems.Sum(x => x.Price * x.Quantity),
                TotalQuantity = cartItems.Sum(x => x.Quantity),
                UserName = $"{user.FirstName} {user.LastName}",
                UserEmail = user.Email,
                UserCity = user.City,
                UserAddress = user.Address,
                UserPostCode = user.PostCode,
                UserPhoneNumber = user.PhoneNumber
            };

            return View(model);
        }
    }
}