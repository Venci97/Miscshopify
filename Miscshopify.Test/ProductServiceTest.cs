using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Miscshopify.Core.Contracts;
using Miscshopify.Core.Models;
using Miscshopify.Core.Services;
using Miscshopify.Infrastructure.Data.Models;
using Miscshopify.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscshopify.Test
{
    public class ProductServiceTest
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;

        [SetUp]
        public async Task Setup()
        {
            dbContext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IAppDbRepository, AppDbRepository>()
                .AddSingleton<ICategoryService, CategoryService>()
                .AddSingleton<IProductService, ProductService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IAppDbRepository>();
            await SeedDbAsync(repo);
        }

        [Test]
        public void AddMustSucceed()
        {
            var product = new ProductViewModel()
            {
                Name = "Tv",
                Description = "Best TV",
                ImagePath = "/image/productImg/asd123.jpg",
                CategoryId = Guid.Parse("11111111-2222-2222-2222-111111111111"),
                Price = 599.99m
            };

            var service = serviceProvider.GetService<IProductService>();

            Assert.DoesNotThrowAsync(async () => await service.Add(product));
        }

        [Test]
        public void AddMustThrow()
        { 

            var service = serviceProvider.GetService<IProductService>();

            Assert.CatchAsync<NullReferenceException>(async () => await service.Add(null), "Cannot add a empty product");
        }

        [Test]
        public void EditMustThrow()
        {
            Guid invalidId = Guid.Parse("11111111-1111-1111-1111-111111111111");

            var service = serviceProvider.GetService<IProductService>();

            Assert.CatchAsync<NullReferenceException>(async () => await service.Edit(invalidId), "Product doesn't exist");
        }

        [Test]
        public void EditUpdateMustSucceed()
        {
            Guid validId = Guid.Parse("11111111-3333-3333-3333-111111111111");

            var productViewModel = new ProductViewModel()
            {
                Id = validId,
                Name = "PS5",
                Description = "1TB",
                CategoryId = Guid.Parse("11111111-2222-2222-2222-111111111111"),

            };

            var service = serviceProvider.GetService<IProductService>();

            Assert.DoesNotThrowAsync(async () => await service.UpdateProductDetails(productViewModel));
        }

        [Test]
        public void RemoveMustSucceed()
        {
            var service = serviceProvider.GetService<IProductService>();

            service.RemoveProduct(Guid.Parse("11111111-3333-3333-3333-111111111111"));

            var productsList = service.GetProducts().Result;

            if (productsList.Count() == 0)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void ProductByCategoryMustSucceed()
        {
            var service = serviceProvider.GetService<IProductService>();

            var products = service.GetProductsByCategory(Guid.Parse("11111111-2222-2222-2222-111111111111"));

            var productsList = service.GetProducts().Result;

            if (productsList.Count() > 1)
            {
                Assert.Pass();
            }
        }
        
        [Test]
        public void ProductDetailsMustThrow()
        {
            Guid invalidId = Guid.Parse("11111111-1111-1111-1111-111111111111");

            var service = serviceProvider.GetService<IProductService>();

            Assert.CatchAsync<NullReferenceException>(async () => await service.ProductDetails(invalidId), "Product not exist");
        }

        [Test]
        public void ProductDetailsMustSucceed()
        { 
            var service = serviceProvider.GetService<IProductService>();

            Assert.DoesNotThrowAsync(async () => await service.ProductDetails(Guid.Parse("11111111-3333-3333-3333-111111111111")));
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }


        private async Task SeedDbAsync(IAppDbRepository repo)
        {
            var category = new Category()
            {
                Id = Guid.Parse("11111111-2222-2222-2222-111111111111"),
                Name = "Gaming Consoles",
                Description = "PS4"
            };

            var product = new Product()
            {
                CategoryId = category.Id,
                Description = "aa",
                Id = Guid.Parse("11111111-3333-3333-3333-111111111111"),
                Name = "asd",
                Price = 10.99m
            };

            await repo.AddAsync(category);
            await repo.AddAsync(product);

            await repo.SaveChangesAsync();
        }
    }
}
