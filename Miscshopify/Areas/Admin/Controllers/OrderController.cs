using Miscshopify.Common.Constants;
using Miscshopify.Core.Contracts;
using Miscshopify.Core.Models;
using Miscshopify.Infrastructure.Data.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Miscshopify.Areas.Admin.Controllers
{
    public class OrderController : AdminBaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetAllOrders();
            return View(orders);
        }

        public async Task<IActionResult> NewOrders()
        {
            var orders = await _orderService.GetNewOrders();
            return View(orders);
        }

        public async Task<IActionResult> OrdersOnTheWay()
        {
            var orders = await _orderService.GetOrdersOnTheWay();
            return View(orders);
        }

        public async Task<IActionResult> OrderDetails(Guid id)
        {
            var orderDetails = await _orderService.GetOrderDetails(id);
            return View(orderDetails);
        }

        [HttpPost]
        public async Task<IActionResult> OrderDetails(OrderViewModel model)
        {
            if (await _orderService.UpdateOrderDetails(model))
            {
                ViewData[GlobalConstants.Messages.Success] = "Order details updated successfully";
            }
            else
            {
                ViewData[GlobalConstants.Messages.Error] = "Failed to update order details";
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePaymentMethod(Guid id, PaymentMethodEnum paymentMethod)
        {
            if (await _orderService.UpdatePaymentMethod(id, paymentMethod))
            {
                ViewData[GlobalConstants.Messages.Success] = "Payment method updated successfully";
            }
            else
            {
                ViewData[GlobalConstants.Messages.Error] = "Failed to update payment method";
            }

            return RedirectToAction(nameof(OrderDetails), new { Id = id });
        }
    }
}
