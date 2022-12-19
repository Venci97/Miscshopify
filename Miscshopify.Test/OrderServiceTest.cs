using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Miscshopify.Core.Contracts;
using Miscshopify.Core.Services;
using Miscshopify.Infrastructure.Data.Models.Enums;
using Miscshopify.Infrastructure.Data.Models;
using Miscshopify.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscshopify.Test
{
    public class OrderServiceTest
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
                .AddSingleton<IOrderService, OrderService>()
                .AddSingleton<IProductService, ProductService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IAppDbRepository>();
            await SeedDbAsync(repo);
        }

        [Test]
        public void CompleteOrderMustSucceed()
        {
            var service = serviceProvider.GetService<IOrderService>();

            Assert.DoesNotThrowAsync(async () => await service.CompleteOrder("11111111-2121-2121-2121-111111111111"));
        }

        [Test]
        public void CompleteOrderMustThrow()
        {
            var service = serviceProvider.GetService<IOrderService>();

            Assert.CatchAsync<NullReferenceException>(async () => await service.CompleteOrder("11111111-2323-2323-2323-111111111111"), "Cart Is Empty");
        }

        [Test]
        public void GetMyOrdersMustSucceed()
        {
            var service = serviceProvider.GetService<IOrderService>();

            var ordersList = service.GetMyOrders("11111111-2121-2121-2121-111111111111").Result;

            Assert.AreNotEqual(0, ordersList.Count());
        }

        [Test]
        public void GetAllOrdersMustSucceed()
        {
            var service = serviceProvider.GetService<IOrderService>();

            var ordersList = service.GetAllOrders().Result;

            Assert.AreNotEqual(0, ordersList.Count());
        }

        [Test]
        public void GetOrdersOnTheWayMustSucceed()
        {
            var service = serviceProvider.GetService<IOrderService>();

            var ordersList = service.GetOrdersOnTheWay().Result;

            Assert.AreEqual(0, ordersList.Count());
        }

        [Test]
        public void GetNewOrdersMustSucceed()
        {
            var service = serviceProvider.GetService<IOrderService>();

            var ordersList = service.GetNewOrders().Result;

            Assert.AreNotEqual(0, ordersList.Count());
        }

        [Test]
        public void OrderDetailsMustSucceed()
        {
            var service = serviceProvider.GetService<IOrderService>();

            bool result = false;
            var order = service.GetOrderDetails(Guid.Parse("11111111-1111-4444-4444-111111111111")).Result;
            
            if (order != null)
            {
                result = true;
            }

            Assert.IsTrue(result);
        }

        [Test]
        public void OrderDetailsMustThrow()
        {
            var service = serviceProvider.GetService<IOrderService>();

            Assert.CatchAsync<NullReferenceException>(async () => await service.GetOrderDetails(Guid.Parse("11111111-7777-1444-4444-111111111111")));
        }

        [Test]
        public void GetOrderMustThrow()
        {
            var service = serviceProvider.GetService<IOrderService>();

            Assert.CatchAsync<NullReferenceException>(async () => await service.GetOrderDetails(Guid.Parse("11111111-7777-1444-4444-111111111111")));
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private async Task SeedDbAsync(IAppDbRepository repo)
        {
            var customer = new ApplicationUser()
            {
                Id = "11111111-2121-2121-2121-111111111111",
                Email = "asd@asd.asd",
                FirstName = "qwerty",
                LastName = "asdfg",
                Address = "asd",
                City = "aasd",
                PostCode = "1234",
                ImagePath = "/asd/asd.jpg",
                Gender = GenderEnum.Male,
                EmailConfirmed = true,
                AccessFailedCount = 0,
                LockoutEnabled = true,
                TwoFactorEnabled = false,
                NormalizedEmail = "ASD@ASD.ASD",
                NormalizedUserName = "ASD@ASD.ASD",
                UserName = "asd@asd.asd",
                PhoneNumber = "1234567890",

            };

            var customer1 = new ApplicationUser()
            {
                Id = "11111111-2323-2323-2323-111111111111",
                Email = "asd1@asd.asd",
                FirstName = "qwerty1",
                LastName = "asdfg1",
                Address = "asd1",
                City = "aasd1",
                PostCode = "12345",
                ImagePath = "/asd1/asd1.jpg",
                Gender = GenderEnum.Male,
                EmailConfirmed = true,
                AccessFailedCount = 0,
                LockoutEnabled = true,
                TwoFactorEnabled = false,
                NormalizedEmail = "ASD1@ASD.ASD",
                NormalizedUserName = "ASD1@ASD.ASD",
                UserName = "asd1@asd.asd",
                PhoneNumber = "0234567890",
            };

            var order = new Order()
            {
                CustomerName = $"{customer.FirstName} {customer.LastName}",
                Id = Guid.Parse("11111111-1111-4444-4444-111111111111"),
                Status = OrderStatusEnum.Pending,
                UserId = customer.Id,
                Items = new List<OrderItem>()
            };

            var category = new Category()
            {
                Id = Guid.Parse("11111111-4444-4444-4444-111111111111"),
                Name = "Gaming Consoles",
                Description = "PS4"
            };

            var product = new Product()
            {
                Id = Guid.Parse("11111111-3333-3333-3333-111111111111"),
                CategoryId = category.Id,
                Description = "asd",
                ImagePath = "/asd/asd.png",
                Name = "PS5",
                Price = 999.99m,
                Category = category
            };

            var cart = new Cart()
            {
                Id = 1,
                CustomerId = customer.Id,
                Items = new List<CartItem>()
            };

            var cartItem = new CartItem()
            {
                Id = Guid.Parse("11111111-1122-1122-1122-111111111111"),
                CustomerId = customer.Id,
                ImagePath = "/qwe.jpeg",
                ProductID = product.Id,
                ProductName = product.Name,
                Quantity = 1,
                UnitPrice = product.Price
            };

            cart.Items.Add(cartItem);

            await repo.AddAsync(customer);
            await repo.AddAsync(customer1);
            await repo.AddAsync(category);
            await repo.AddAsync(product);
            await repo.AddAsync(cart);
            await repo.AddAsync(cartItem);
            await repo.AddAsync(order);

            await repo.SaveChangesAsync();
        }
    }
}
