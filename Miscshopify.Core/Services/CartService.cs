using Microsoft.EntityFrameworkCore;
using Miscshopify.Core.Contracts;
using Miscshopify.Core.Models;
using Miscshopify.Infrastructure.Data.Models;
using Miscshopify.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscshopify.Core.Services
{
    public class CartService : ICartService
    {
        private readonly IAppDbRepository repo;
        private readonly IProductService productService;

        public CartService(IAppDbRepository _repo, IProductService _productService)
        {
            repo = _repo;
            productService = _productService;
        }

        public async Task AddToCart(Guid productId, string userId)
        {
            var product = productService.GetProductById(productId).Result;

            var cart = repo.All<Cart>()
                .FirstOrDefault(c => c.CustomerId == userId);

            if (cart == null)
            {
                cart = new Cart()
                {
                    CustomerId = userId,
                    CartItems = new List<CartItem>()
                };

                await repo.AddAsync(cart);
            }

            cart.CartItems.Add(new CartItem()
            {
                CustomerId = userId,
                ImagePath = product.ImagePath,
                ProductID = product.Id,
                Quantity = 1,
                UnitPrice = product.Price,
                ProductName = product.Name
            });

            repo.SaveChanges();
        }

        public async Task Checkout(string userId)
        {
            var cart = repo.All<Cart>()
                .First(c => c.CustomerId == userId);

            var order = new Order()
            {
                Status = Infrastructure.Data.Models.Enums.OrderStatusEnum.Pending
            };

            foreach (var item in cart.CartItems)
            {
                order.Items.Add(item);
            }

            repo.Delete(cart);

            await repo.AddAsync(order);
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<CartItemViewModel>> GetCartItems(string userId)
        {
            return await repo.All<CartItem>()
                .Where(c => c.CustomerId == userId)
                .Select(c => new CartItemViewModel()
                {
                    Id = c.Id,
                    ProductId = c.ProductID,
                    ImagePath = c.ImagePath,
                    ProductName = c.ProductName,
                    Price = c.UnitPrice,
                    Quantity = c.Quantity
                })
                .ToListAsync();
        }

        public void RemoveFromCart(Guid cartItemId, string userId)
        {
            var item = repo.All<CartItem>()
                .First(i => i.Id == cartItemId);

            repo.Delete(item);

            repo.SaveChanges();
        }
    }
}
