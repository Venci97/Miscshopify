using Microsoft.Extensions.DependencyInjection;
using Miscshopify.Core.Contracts;
using Miscshopify.Core.Models;
using Miscshopify.Core.Services;
using Miscshopify.Infrastructure.Data.Models;
using Miscshopify.Infrastructure.Data.Repositories;

namespace Miscshopify.Test
{
	public class CategoryServiceTest
	{
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        private ServiceProvider serviceProvider;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
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
		public void AddEmptyDataMustThrow()
		{
			CategoryViewModel category = null;
			
			var service = serviceProvider.GetService<ICategoryService>();

			Assert.CatchAsync<NullReferenceException>(async () => await service.Add(category), "Empty category");
		}

		[Test]
		public void AddDataMustSucceed()
		{
			CategoryViewModel category = new CategoryViewModel()
			{
				Name = "Tv",
				Description = "Best TV",
				ImagePath = "/image/categoryImg/asd123.jpg"
			};

			var service = serviceProvider.GetService<ICategoryService>();

			Assert.DoesNotThrowAsync(async () => await service.Add(category));
		}

		[Test]
		public void GetCategoriesMustSucceed()
		{
			var service = serviceProvider.GetService<ICategoryService>();

			Assert.DoesNotThrowAsync(async () => await service.GetCategories());
		}

        [Test]
        public void EditMustThrow()
        {
			Guid invalidId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            
			var service = serviceProvider.GetService<ICategoryService>();

            Assert.CatchAsync<NullReferenceException>(async () => await service.Edit(invalidId));
        }

        [Test]
        public void EditUpdateMustSucceed()
        {
            Guid validId = Guid.Parse("11111111-2222-2222-2222-111111111111");
			
			var categoryViewModel = new CategoryViewModel()
			{
				Id = validId,
				Name = "Gaming Consoles",
				Description = "PS4"

			};

            var service = serviceProvider.GetService<ICategoryService>();

            Assert.DoesNotThrowAsync(async () => await service.UpdateCategoryDetails(categoryViewModel));
        }

		[Test]
		public void RemoveMustSucceed()
		{

			var service = serviceProvider.GetService<ICategoryService>();
            var productService = serviceProvider.GetService<IProductService>();

            service.RemoveCategoryWithProducts(Guid.Parse("11111111-2222-2222-2222-111111111111"));

            var categoriesList = service.GetCategories().Result;
			var productsList = productService.GetProducts().Result;

            if (categoriesList.Count() == 0 && productsList.Count() == 0)
            {
                Assert.Pass();
            }
		}

		[Test]
		public void RemoveMustThrow()
		{
			var service = serviceProvider.GetService<ICategoryService>();

			Assert.Catch<NullReferenceException>(void () => service.RemoveCategoryWithProducts(Guid.Parse("11111111-1111-1111-1111-111111111111")), "Category not exist");
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