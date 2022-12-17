using Miscshopify.Core.Models;
using Miscshopify.Infrastructure.Data.Models;

namespace Miscshopify.Core.Contracts
{
    public interface IOrderService
    {
        Task CompleteOrder(string userId);
        Task<IEnumerable<OrderViewModel>> GetNewOrders();
        Task<IEnumerable<OrderViewModel>> GetOrdersOnTheWay();
        Task<IEnumerable<OrderViewModel>> GetAllOrders();
        Task<OrderViewModel> GetOrderDetails(Guid Id);
        Task<Order> GetOrderById(Guid Id);
        Task<bool> UpdateOrderDetails(OrderViewModel model);
        Task<IEnumerable<OrderViewModel>> GetMyOrders(string userId);


	}
}
