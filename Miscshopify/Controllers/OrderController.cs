using Microsoft.AspNetCore.Mvc;
using Miscshopify.Core.Contracts;
using Miscshopify.Infrastructure.Data.Models.Enums;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Miscshopify.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService _orderService)
        {
            orderService = _orderService;
        }

        [HttpGet]
        public async Task<IActionResult> CompleteOrder(PaymentMethodEnum paymentMethod)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await orderService.CompleteOrder(userId, paymentMethod);

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
