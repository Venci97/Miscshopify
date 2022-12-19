using Microsoft.AspNetCore.Mvc;
using Miscshopify.Common.Constants;
using Miscshopify.Core.Contracts;
using Miscshopify.Core.Models;
using Miscshopify.Core.Services;

namespace Miscshopify.Areas.Admin.Controllers
{
    public class OrderController : AdminBaseController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService _orderService)
        {
            orderService = _orderService;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await orderService.GetAllOrders();

            return View(orders);
        }

        public async Task<IActionResult> NewOrders()
        {
            var orders = await orderService.GetNewOrders();
            
            return View(orders);
        }

        public async Task<IActionResult> OrdersOnTheWay()
        {
            var orders = await orderService.GetOrdersOnTheWay();
            
            return View(orders);
        }

        public async Task<IActionResult> OrderDetails(Guid Id)
        {
            var orderDetails = await orderService.GetOrderDetails(Id);

            return View(orderDetails);
        }

		[HttpPost]
		public async Task<IActionResult> OrderDetails(OrderViewModel model)
        {

			if (await orderService.UpdateOrderDetails(model))
			{
				ViewData[GlobalConstants.Messages.Success] = "Successful";
			}
			else
			{
				ViewData[GlobalConstants.Messages.Error] = "Error! Something happen!";
			}

			return RedirectToAction(nameof(Index));
		}
	}
}
