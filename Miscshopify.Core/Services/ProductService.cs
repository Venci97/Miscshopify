using Microsoft.EntityFrameworkCore;
using Miscshopify.Core.Contracts;
using Miscshopify.Core.Models;
using Miscshopify.Infrastructure.Data.Models;
using Miscshopify.Infrastructure.Data.Repositories;

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
            if (model == null)
            {
                throw new NullReferenceException("Cannot add a empty product");
            }

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
            var product = await repo.GetByIdAsync<Product>(id);

            if (product == null)
            {
                throw new NullReferenceException("Product doesn't exist");
            }

            return new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
        }

        public async Task<bool> UpdateProductDetails(ProductViewModel model)
        {
            bool result = false;
            var product = await repo.GetByIdAsync<Product>(model.Id);

            if (product != null)
            {
                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductsByCategory(Guid Id)
        {
            return await repo.All<Product>()
                .Where(c => c.CategoryId == Id)
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

        public async Task<ProductViewModel> ProductDetails(Guid id)
        {
            var product = await repo.GetByIdAsync<Product>(id);

            if (product == null)
            {
                throw new NullReferenceException("Product not exist");
            }

            return new ProductViewModel()
            {
                Id = product.Id,
                ImagePath = product.ImagePath,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
        }

        public void RemoveProduct(Guid productId)
        {
            var product = repo.All<Product>()
                .First(i => i.Id == productId);

            repo.Delete(product);

            repo.SaveChanges();
        }

        public async Task<Product> GetProductById(Guid id)
        {
            return await repo.GetByIdAsync<Product>(id);
        }
    }
}
