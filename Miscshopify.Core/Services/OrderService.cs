using Microsoft.EntityFrameworkCore;
using Miscshopify.Core.Contracts;
using Miscshopify.Core.Models;
using Miscshopify.Infrastructure.Data.Models;
using Miscshopify.Infrastructure.Data.Repositories;

namespace Miscshopify.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IAppDbRepository repo;

        public OrderService(IAppDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task CompleteOrder(string userId)
        {

			var user = await repo.GetByIdAsync<ApplicationUser>(userId);
			var cart = repo.All<Cart>()
                .First(c => c.CustomerId == userId);
            var order = new Order()
            {
                Status = Infrastructure.Data.Models.Enums.OrderStatusEnum.Pending,
                UserId = userId,
                CustomerName = $"{user.FirstName} {user.LastName}"
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
					Status = c.Status
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
					Status = c.Status
                })
                .ToListAsync();

            return order;
        }

        public async Task<OrderViewModel> GetOrderDetails(Guid Id)
        {
            var order = await repo.GetByIdAsync<Order>(Id);
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
                Status = order.Status
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

				await repo.SaveChangesAsync();
				result = true;
			}

			return result;
		}
	}
}
