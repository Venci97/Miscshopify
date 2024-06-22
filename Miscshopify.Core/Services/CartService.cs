using Microsoft.EntityFrameworkCore;
using Miscshopify.Core.Contracts;
using Miscshopify.Core.Models;
using Miscshopify.Infrastructure.Data.Models;
using Miscshopify.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var product = await productService.GetProductById(productId);

            if (product == null)
            {
                throw new NullReferenceException("Product doesn't exist");
            }

            var cart = repo.All<Cart>()
                .FirstOrDefault(c => c.CustomerId == userId);

            if (cart == null)
            {
                cart = new Cart()
                {
                    CustomerId = userId,
                    Items = new List<CartItem>()
                };

                await repo.AddAsync(cart);
            }

            var existingItem = cart.Items.FirstOrDefault(i => i.ProductID == productId);

            if (existingItem == null)
            {
                cart.Items.Add(new CartItem()
                {
                    CustomerId = userId,
                    ImagePath = product.ImagePath,
                    ProductID = product.Id,
                    Quantity = 1,
                    UnitPrice = product.Price, // Set initial unit price when adding new item
                    ProductName = product.Name
                });
            }
            else
            {
                existingItem.Quantity += 1;
                existingItem.UnitPrice = product.Price * existingItem.Quantity; // Update unit price for existing item
            }

            await repo.SaveChangesAsync(); // Save changes asynchronously
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

        public async Task UpdateCartItemQuantity(Guid cartItemId, int quantity, string userId)
        {
            var item = await repo.All<CartItem>()
                .FirstOrDefaultAsync(i => i.Id == cartItemId && i.CustomerId == userId);

            if (item != null)
            {
                item.Quantity = quantity;
                item.UnitPrice = (await productService.GetProductById(item.ProductID)).Price;
                await repo.SaveChangesAsync();
            }
        }

        public void RemoveFromCart(Guid cartItemId)
        {
            var item = repo.All<CartItem>()
                .First(i => i.Id == cartItemId);

            repo.Delete(item);
            repo.SaveChanges();
        }
    }
}
