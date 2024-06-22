using Miscshopify.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Miscshopify.Core.Contracts
{
    public interface ICartService
    {
        Task AddToCart(Guid productId, string userId);
        void RemoveFromCart(Guid CartItemId);
        Task<IEnumerable<CartItemViewModel>> GetCartItems(string userId);
        Task UpdateCartItemQuantity(Guid cartItemId, int quantity, string userId);
    }
}
