using Miscshopify.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscshopify.Core.Contracts
{
    public interface ICartService
    {
        Task AddToCart(Guid productId, string userId);
        void RemoveFromCart(Guid CartItemId, string userId);
        Task<IEnumerable<CartItemViewModel>> GetCartItems(string userId);
    }
}
