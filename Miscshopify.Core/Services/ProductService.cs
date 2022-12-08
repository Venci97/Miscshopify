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
    public class ProductService : IProductService
    {
        private readonly IAppDbRepository repo;

        public ProductService(IAppDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task Add(ProductViewModel model)
        {
            var cat = await repo.GetByIdAsync<Category>(model.CategoryId);

            var product = new Product()
            {
                ImagePath = model.ImagePath,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                CategoryId = model.CategoryId
            };

            cat.Products.Add(product);

            await repo.AddAsync(product);
            await repo.SaveChangesAsync();

        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            return await repo.All<Product>()
                .Select(c => new ProductViewModel()
                {
                    Id = c.Id,
                    ImagePath = c.ImagePath,
                    Name = c.Name,
                    Description = c.Description,
                    Price = c.Price
                })
                .ToListAsync();
        }

        public async Task<ProductViewModel> Edit(Guid id)
        {
            var cat = await repo.GetByIdAsync<Product>(id);

            return new ProductViewModel()
            {
                Id = cat.Id,
                Name = cat.Name,
                Description = cat.Description,
                Price = cat.Price
            };
        }

        public async Task<bool> UpdateProductDetails(ProductViewModel model)
        {
            bool result = false;
            var cat = await repo.GetByIdAsync<Product>(model.Id);

            if (cat != null)
            {
                cat.Name = model.Name;
                cat.Description = model.Description;
                cat.Price = model.Price;

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }
        
    }
}
