using Miscshopify.Core.Models;

namespace Miscshopify.Core.Contracts
{
    public interface IOrderService
    {
        Task PlaceOrder(CustomerOrderViewModel order);
    }
}
