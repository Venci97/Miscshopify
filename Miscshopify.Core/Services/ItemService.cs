using Miscshopify.Core.Contracts;
using Miscshopify.Core.Models;
using Miscshopify.Infrastructure.Data.Models;
using Miscshopify.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Miscshopify.Core.Services
{
    public class ItemService : IItemService
    {
        private readonly IAppDbRepository repo;
        private readonly IProductService productService;
        private IList<CartItem> cart;

        public ItemService(IAppDbRepository _repo, IProductService _productService)
        {
            repo = _repo;
            productService = _productService;
            cart = new List<CartItem>();
        }

        //public ActionResult AddToCart(Guid productId)
        //{
        //    var prod = productService.GetProductById(productId).Result;
        //    var item = new CartItem()
        //    {
        //        Product = prod
        //    };

        //    if (cart.Contains(item))
        //    {
        //        cart(item).Quantity
        //    }
        //    else
        //    {
        //        var product = productService.GetProductById(productId).Result;
        //        cart.f
        //    }
        //    return Redirect("Index");
        //}

        //public void RemoveFromCart(Guid Id)
        //{
        //    Product product = productService.GetProductById(Id).Result;

        //    cart.Remove(product);
        //}

        public async Task Add(CustomerOrderViewModel model)
        {
            var cart = new CartItem()
            {
                 
            };

            await repo.AddAsync(cart);
            await repo.SaveChangesAsync();
        }
    }
}
