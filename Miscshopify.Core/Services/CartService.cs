using Microsoft.EntityFrameworkCore;
using Miscshopify.Core.Contracts;
using Miscshopify.Core.Models;
using Miscshopify.Infrastructure.Data.Models;
using Miscshopify.Infrastructure.Data.Repositories;

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

            var item = repo.All<CartItem>()
                .FirstOrDefault(i => i.CustomerId == userId && i.ProductID == productId);

			if (item == null)
            {
                cart.Items.Add(new CartItem()
                {
                    CustomerId = userId,
                    ImagePath = product.ImagePath,
                    ProductID = product.Id,
                    Quantity = 1,
                    UnitPrice = product.Price,
                    ProductName = product.Name
                });

            }
            else
            {
                item.Quantity += 1;
                item.UnitPrice = product.Price * item.Quantity;
            }
            repo.SaveChanges();
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

		public void RemoveFromCart(Guid cartItemId)
        {
            var item = repo.All<CartItem>()
                .First(i => i.Id == cartItemId);

            repo.Delete(item);

            repo.SaveChanges();
        }
    }
}
