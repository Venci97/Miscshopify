using Miscshopify.Core.Models;

namespace Miscshopify.Core.Contracts
{
    public interface ICartService
    {
        Task AddToCart(Guid productId, string userId);
        void RemoveFromCart(Guid CartItemId);
        Task<IEnumerable<CartItemViewModel>> GetCartItems(string userId);
    }
}
