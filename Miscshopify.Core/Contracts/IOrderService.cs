using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Miscshopify.Core.Models;
using Miscshopify.Infrastructure.Data.Models;
using Miscshopify.Infrastructure.Data.Models.Enums;
using Stripe;

namespace Miscshopify.Core.Contracts
{
    public interface IOrderService
    {
        Task CompleteOrder(string userId, PaymentMethodEnum paymentMethod);
        Task<IEnumerable<OrderViewModel>> GetNewOrders();
        Task<IEnumerable<OrderViewModel>> GetOrdersOnTheWay();
        Task<IEnumerable<OrderViewModel>> GetAllOrders();
        Task<OrderViewModel> GetOrderDetails(Guid Id);
        Task<Order> GetOrderById(Guid Id);
        Task<bool> UpdateOrderDetails(OrderViewModel model);
        Task<bool> UpdatePaymentMethod(Guid id, PaymentMethodEnum paymentMethod);
        Task<IEnumerable<OrderViewModel>> GetMyOrders(string userId);
    }
}
