﻿using Microsoft.Extensions.DependencyInjection;
using Miscshopify.Core.Contracts;
using Miscshopify.Core.Services;
using Miscshopify.Infrastructure.Data.Models;
using Miscshopify.Infrastructure.Data.Models.Enums;
using Miscshopify.Infrastructure.Data.Repositories;
using NUnit.Framework.Legacy;

namespace Miscshopify.Test
{
    public class UserServiceTest
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
                .AddSingleton<IUserService, UserService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IAppDbRepository>();
            await SeedDbAsync(repo);
        }

        [Test]
        public void GetUsersMustSucceed()
        {
            var service = serviceProvider.GetService<IUserService>();

            var userList = service.GetUsers().Result;

            ClassicAssert.AreNotEqual(0, userList.Count());
        }

        [Test]
        public void EditUpdateMustSucceed()
        {
            var service = serviceProvider.GetService<IUserService>();

            var user = service.EditUser("11111111-2121-2121-2121-111111111111").Result;

            Assert.DoesNotThrowAsync(async () => await service.UpdateUserDetails(user));
        }

        [Test]
        public void GetUserByIdMustSucceed()
        {
            var service = serviceProvider.GetService<IUserService>();

            var user = service.GetUserById("11111111-2121-2121-2121-111111111111").Result;

            ClassicAssert.NotNull(user);
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

            //var order = new Order()
            //{
            //    CustomerName = $"{customer.FirstName} {customer.LastName}",
            //    Id = Guid.Parse("11111111-1111-4444-4444-111111111111"),
            //    Status = OrderStatusEnum.Pending,
            //    UserId = customer.Id,
            //    Items = new List<OrderItem>()
            //};

            //var category = new Category()
            //{
            //    Id = Guid.Parse("11111111-4444-4444-4444-111111111111"),
            //    Name = "Gaming Consoles",
            //    Description = "PS4"
            //};

            //var product = new Product()
            //{
            //    Id = Guid.Parse("11111111-3333-3333-3333-111111111111"),
            //    CategoryId = category.Id,
            //    Description = "asd",
            //    ImagePath = "/asd/asd.png",
            //    Name = "PS5",
            //    Price = 999.99m,
            //    Category = category
            //};

            //var cart = new Cart()
            //{
            //    Id = 1,
            //    CustomerId = customer.Id,
            //    Items = new List<CartItem>()
            //};

            //var cartItem = new CartItem()
            //{
            //    Id = Guid.Parse("11111111-1122-1122-1122-111111111111"),
            //    CustomerId = customer.Id,
            //    ImagePath = "/qwe.jpeg",
            //    ProductID = product.Id,
            //    ProductName = product.Name,
            //    Quantity = 1,
            //    UnitPrice = product.Price
            //};

            //cart.Items.Add(cartItem);

            await repo.AddAsync(customer);
            await repo.AddAsync(customer1);
            //await repo.AddAsync(category);
            //await repo.AddAsync(product);
            //await repo.AddAsync(cart);
            //await repo.AddAsync(cartItem);
            //await repo.AddAsync(order);

            await repo.SaveChangesAsync();
        }
    }
}
