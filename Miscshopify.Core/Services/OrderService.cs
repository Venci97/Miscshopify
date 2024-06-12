using Microsoft.EntityFrameworkCore;
using Miscshopify.Core.Contracts;
using Miscshopify.Core.Models;
using Miscshopify.Infrastructure.Data.Models;
using Miscshopify.Infrastructure.Data.Models.Enums;
using Miscshopify.Infrastructure.Data.Repositories;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Miscshopify.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IAppDbRepository repo;

        public OrderService(IAppDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task CompleteOrder(string userId, PaymentMethodEnum paymentMethod)
        {
            var user = await repo.GetByIdAsync<ApplicationUser>(userId);
            var cart = repo.All<Cart>()
                .FirstOrDefault(c => c.CustomerId == userId);

            if (cart == null)
            {
                throw new NullReferenceException("Cart Is Empty");
            }

            var order = new Order()
            {
                Status = Infrastructure.Data.Models.Enums.OrderStatusEnum.Pending,
                UserId = userId,
                CustomerName = $"{user.FirstName} {user.LastName}",
                PaymentMethod = paymentMethod
            };

            var items = repo.All<CartItem>()
                .Where(i => i.CustomerId == userId);

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    CustomerId = userId,
                    ImagePath = item.ImagePath,
                    ProductId = item.ProductID,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    Price = item.UnitPrice,
                    OrderId = order.Id
                };

                order.Items.Add(orderItem);
                await repo.AddAsync(orderItem);
                repo.Delete(item);
            }

            repo.Delete(cart);

            await repo.AddAsync(order);
            await repo.SaveChangesAsync();
        }

        public async Task<bool> UpdatePaymentMethod(Guid id, PaymentMethodEnum paymentMethod)
        {
            var order = await repo.GetByIdAsync<Order>(id);

            if (order != null)
            {
                order.PaymentMethod = paymentMethod;
                await repo.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<OrderViewModel>> GetMyOrders(string userId)
        {
            var order = await repo.All<Order>()
                .Where(c => c.UserId == userId)
                .Select(c => new OrderViewModel()
                {
                    Id = c.Id,
                    CustomerId = c.UserId,
                    CustomerName = c.CustomerName,
                    Status = c.Status,
                    PaymentMethod = c.PaymentMethod
                })
                .ToListAsync();

            return order;
        }

        public async Task<IEnumerable<OrderViewModel>> GetAllOrders()
        {
            var order = await repo.All<Order>()
                .Select(c => new OrderViewModel()
                {
                    Id = c.Id,
                    CustomerId = c.UserId,
                    CustomerName = c.CustomerName,
                    Status = c.Status,
                    PaymentMethod = c.PaymentMethod
                })
                .ToListAsync();

            return order;
        }

        public async Task<IEnumerable<OrderViewModel>> GetNewOrders()
        {
            var order = await repo.All<Order>()
                .Where(c => c.Status == Infrastructure.Data.Models.Enums.OrderStatusEnum.Pending)
                .Select(c => new OrderViewModel()
                {
                    Id = c.Id,
                    CustomerId = c.UserId,
                    CustomerName = c.CustomerName,
                    Status = c.Status,
                    PaymentMethod = c.PaymentMethod
                })
                .ToListAsync();

            return order;
        }

        public async Task<Order> GetOrderById(Guid Id)
        {
            return await repo.GetByIdAsync<Order>(Id);
        }

        public async Task<IEnumerable<OrderViewModel>> GetOrdersOnTheWay()
        {
            var order = await repo.All<Order>()
                .Where(c => c.Status == Infrastructure.Data.Models.Enums.OrderStatusEnum.OnTheWay)
                .Select(c => new OrderViewModel()
                {
                    Id = c.Id,
                    CustomerId = c.UserId,
                    CustomerName = c.CustomerName,
                    Status = c.Status,
                    PaymentMethod = c.PaymentMethod
                })
                .ToListAsync();

            return order;
        }

        public async Task<OrderViewModel> GetOrderDetails(Guid Id)
        {
            var order = await repo.GetByIdAsync<Order>(Id);

            if (order == null)
            {
                throw new NullReferenceException("Order not exist");
            }

            var user = await repo.GetByIdAsync<ApplicationUser>(order.UserId);

            var orderView = new OrderViewModel()
            {
                Id = order.Id,  
                CustomerAddress = user.Address,
                CustomerCity = user.City,
                CustomerEmail = user.Email,
                CustomerName = $"{user.FirstName} {user.LastName}",
                CustomerPhoneNumber = user.PhoneNumber,
                CustomerPostCode = user.PostCode,
                CustomerId = order.UserId,
                Status = order.Status,
                PaymentMethod = order.PaymentMethod
            };

            var orderItem = repo.All<OrderItem>()
                .Where(i => i.OrderId == order.Id);

            foreach (var item in orderItem)
            {
                orderView.Items.Add(item);
            }

            return orderView;
        }

        public async Task<bool> UpdateOrderDetails(OrderViewModel model)
        {
            bool result = false;
            var order = await repo.GetByIdAsync<Order>(model.Id);

            if (order != null)
            {
                order.Status = model.Status;
                order.PaymentMethod = model.PaymentMethod;

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }
    }
}
    