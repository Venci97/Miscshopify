using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Miscshopify.Core.Contracts;
using System.Security.Claims;

namespace Miscshopify.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService _orderService)
        {
            orderService = _orderService;
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await orderService.CompleteOrder(userId);

            return View();
        }

		public async Task<IActionResult> MyOrders()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var orders = await orderService.GetMyOrders(userId);

			return View(orders);
		}

		public async Task<IActionResult> OrderDetails(Guid Id)
		{
			var orderDetails = await orderService.GetOrderDetails(Id);

			return View(orderDetails);
		}
	}
}
