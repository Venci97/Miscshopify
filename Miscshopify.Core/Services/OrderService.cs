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
            try
            {
                Console.WriteLine($"=== OrderService.CompleteOrder STARTED ===");
                Console.WriteLine($"UserId: {userId}, PaymentMethod: {paymentMethod}");

                var user = await repo.GetByIdAsync<ApplicationUser>(userId);
                Console.WriteLine($"User found: {user != null}");

                var cart = repo.All<Cart>()
                    .FirstOrDefault(c => c.CustomerId == userId);
                Console.WriteLine($"Cart found: {cart != null}");

                if (cart == null)
                {
                    throw new NullReferenceException("Cart Is Empty");
                }

                var items = repo.All<CartItem>()
                    .Where(i => i.CustomerId == userId).ToList();
                Console.WriteLine($"Cart items count: {items.Count}");

                if (!items.Any())
                {
                    throw new NullReferenceException("No items in cart");
                }

                decimal totalAmount = items.Sum(i => i.UnitPrice * i.Quantity);
                Console.WriteLine($"Total amount: {totalAmount}");

                var order = new Order()
                {
                    Id = Guid.NewGuid(),
                    Status = OrderStatusEnum.Pending,
                    UserId = userId,
                    CustomerName = $"{user.FirstName} {user.LastName}",
                    PaymentMethod = paymentMethod,
                    TotalAmount = totalAmount,
                    IsPaid = (paymentMethod == PaymentMethodEnum.Card),
                    PaymentDate = (paymentMethod == PaymentMethodEnum.Card) ? DateTime.UtcNow : null,
                    OrderDate = DateTime.UtcNow,

                    OrderCustomerAddress = user.Address,
                    OrderCustomerCity = user.City,
                    OrderCustomerPostCode = user.PostCode,
                    OrderCustomerEmail = user.Email,
                    OrderCustomerPhoneNumber = user.PhoneNumber
                };

                Console.WriteLine($"Order created with ID: {order.Id}");

                foreach (var item in items)
                {
                    var orderItem = new OrderItem()
                    {
                        Id = Guid.NewGuid(),
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
                    Console.WriteLine($"Moved item to order: {item.ProductName}");
                }

                repo.Delete(cart);
                Console.WriteLine("Cart deleted");

                await repo.AddAsync(order);
                await repo.SaveChangesAsync();

                Console.WriteLine($"=== OrderService.CompleteOrder COMPLETED SUCCESSFULLY ===");
                Console.WriteLine($"Order ID: {order.Id} saved to database");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"=== ERROR in OrderService.CompleteOrder: {ex.Message} ===");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                throw;
            }
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
                CustomerAddress = order.OrderCustomerAddress ?? user.Address,
                CustomerCity = order.OrderCustomerCity ?? user.City,
                CustomerEmail = order.OrderCustomerEmail ?? user.Email,
                CustomerName = order.CustomerName,
                CustomerPhoneNumber = order.OrderCustomerPhoneNumber ?? user.PhoneNumber,
                CustomerPostCode = order.OrderCustomerPostCode ?? user.PostCode,
                CustomerId = order.UserId,
                Status = order.Status,
                PaymentMethod = order.PaymentMethod,

                OrderCustomerAddress = order.OrderCustomerAddress,
                OrderCustomerCity = order.OrderCustomerCity,
                OrderCustomerPostCode = order.OrderCustomerPostCode,
                OrderCustomerEmail = order.OrderCustomerEmail,
                OrderCustomerPhoneNumber = order.OrderCustomerPhoneNumber
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

        public async Task MarkOrderAsPaidAsync(string orderId)
        {
            var orderGuid = Guid.Parse(orderId);
            var order = await repo.GetByIdAsync<Order>(orderGuid);

            if (order != null)
            {
                order.IsPaid = true;
                order.PaymentDate = DateTime.UtcNow;
                await repo.SaveChangesAsync();
            }
        }
        public async Task<decimal> GetCartTotalAsync(string userId)
        {
            var items = repo.All<CartItem>().Where(i => i.CustomerId == userId);
            decimal total = 0;

            await foreach (var item in items.AsAsyncEnumerable())
            {
                total += item.UnitPrice * item.Quantity;
            }

            return total;
        }

        public async Task<IEnumerable<Order>> GetCompletedOrders()
        {
            return await repo.All<Order>()
                .Where(o => o.Status == OrderStatusEnum.Completed)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }

    }
}
