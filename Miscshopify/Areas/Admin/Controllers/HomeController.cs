using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Miscshopify.Infrastructure.Data;
using Miscshopify.Infrastructure.Data.Models;
using Miscshopify.Infrastructure.Data.Models.Enums;

namespace Miscshopify.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        private readonly MiscshopifyContext _context;

        public HomeController(MiscshopifyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            await LoadSidebarData();
            var dashboardData = await GetDashboardData();
            return View(dashboardData);
        }

        private async Task LoadSidebarData()
        {
            // Load real data for sidebar
            var totalUsers = await _context.Users.CountAsync();
            var totalCategories = await _context.Categories.CountAsync();
            var totalProducts = await _context.Products.CountAsync();
            var newOrders = await _context.Orders.CountAsync(o => o.Status == OrderStatusEnum.Pending);
            var ordersOnTheWay = await _context.Orders.CountAsync(o => o.Status == OrderStatusEnum.Completed);
            var allOrders = await _context.Orders.CountAsync();

            ViewData["TotalUsers"] = totalUsers;
            ViewData["TotalCategories"] = totalCategories;
            ViewData["TotalProducts"] = totalProducts;
            ViewData["NewOrders"] = newOrders;
            ViewData["OrdersOnTheWay"] = ordersOnTheWay;
            ViewData["AllOrders"] = allOrders;
        }

        private async Task<DashboardViewModel> GetDashboardData()
        {
            var totalOrders = await _context.Orders.CountAsync();

            var totalRevenue = await _context.Orders
                .Where(o => o.IsPaid)
                .SumAsync(o => o.TotalAmount);

            var totalCustomers = await _context.Users.CountAsync();

            var totalProducts = await _context.Products.CountAsync();

            var currentDate = DateTime.UtcNow;
            var firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            var firstDayOfLastMonth = firstDayOfMonth.AddMonths(-1);
            var lastDayOfLastMonth = firstDayOfMonth.AddDays(-1);

            var currentMonthOrders = await _context.Orders
                .Where(o => o.OrderDate >= firstDayOfMonth)
                .CountAsync();

            var lastMonthOrders = await _context.Orders
                .Where(o => o.OrderDate >= firstDayOfLastMonth && o.OrderDate <= lastDayOfLastMonth)
                .CountAsync();

            var ordersPercentageChange = CalculatePercentageChange(currentMonthOrders, lastMonthOrders);

            var currentMonthRevenue = await _context.Orders
                .Where(o => o.IsPaid && o.OrderDate >= firstDayOfMonth)
                .SumAsync(o => (double?)o.TotalAmount) ?? 0;

            var lastMonthRevenue = await _context.Orders
                .Where(o => o.IsPaid && o.OrderDate >= firstDayOfLastMonth && o.OrderDate <= lastDayOfLastMonth)
                .SumAsync(o => (double?)o.TotalAmount) ?? 0;

            var revenuePercentageChange = CalculatePercentageChange(currentMonthRevenue, lastMonthRevenue);

            var currentMonthCustomers = await _context.Users
                .Where(u => u.CreationDate >= firstDayOfMonth)
                .CountAsync();

            var lastMonthCustomers = await _context.Users
                .Where(u => u.CreationDate >= firstDayOfLastMonth && u.CreationDate <= lastDayOfLastMonth)
                .CountAsync();

            var customersPercentageChange = CalculatePercentageChange(currentMonthCustomers, lastMonthCustomers);

            var productsPercentageChange = 3.0; // Default value

            var recentActivities = await GetRecentActivities();

            return new DashboardViewModel
            {
                TotalOrders = totalOrders,
                TotalRevenue = totalRevenue,
                TotalCustomers = totalCustomers,
                TotalProducts = totalProducts,
                OrdersPercentageChange = ordersPercentageChange,
                RevenuePercentageChange = revenuePercentageChange,
                CustomersPercentageChange = customersPercentageChange,
                ProductsPercentageChange = productsPercentageChange,
                RecentActivities = recentActivities
            };
        }

        private async Task<List<RecentActivity>> GetRecentActivities()
        {
            var activities = new List<RecentActivity>();

            var recentOrders = await _context.Orders
                .Include(o => o.User)
                .OrderByDescending(o => o.OrderDate)
                .Take(3)
                .ToListAsync();

            foreach (var order in recentOrders)
            {
                activities.Add(new RecentActivity
                {
                    Type = "Order",
                    Description = $"New order #{order.Id.ToString().Substring(0, 8)} placed by {order.CustomerName}",
                    Timestamp = order.OrderDate,
                    Icon = "fas fa-shopping-cart",
                    IconColor = "text-blue-600"
                });
            }

            var recentUsers = await _context.Users
                .OrderByDescending(u => u.CreationDate)
                .Take(1)
                .ToListAsync();

            foreach (var user in recentUsers)
            {
                activities.Add(new RecentActivity
                {
                    Type = "User",
                    Description = $"New user {user.FirstName} {user.LastName} registered",
                    Timestamp = user.CreationDate,
                    Icon = "fas fa-user-plus",
                    IconColor = "text-green-600"
                });
            }

            var recentProduct = await _context.Products
                .Include(p => p.Category)
                .OrderByDescending(p => p.Id)
                .FirstOrDefaultAsync();

            if (recentProduct != null)
            {
                activities.Add(new RecentActivity
                {
                    Type = "Product",
                    Description = $"Product {recentProduct.Name} added to {recentProduct.Category?.Name}",
                    Timestamp = DateTime.UtcNow.AddHours(-3),
                    Icon = "fas fa-box",
                    IconColor = "text-purple-600"
                });
            }

            return activities.OrderByDescending(a => a.Timestamp).Take(4).ToList();
        }

        private double CalculatePercentageChange(int current, int previous)
        {
            if (previous == 0) return current > 0 ? 100 : 0;
            return Math.Round(((current - previous) / (double)previous) * 100, 1);
        }

        private double CalculatePercentageChange(double current, double previous)
        {
            if (previous == 0) return current > 0 ? 100 : 0;
            return Math.Round(((current - previous) / previous) * 100, 1);
        }
    }

    public class DashboardViewModel
    {
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TotalCustomers { get; set; }
        public int TotalProducts { get; set; }
        public double OrdersPercentageChange { get; set; }
        public double RevenuePercentageChange { get; set; }
        public double CustomersPercentageChange { get; set; }
        public double ProductsPercentageChange { get; set; }
        public List<RecentActivity> RecentActivities { get; set; } = new();
    }

    public class RecentActivity
    {
        public string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public string Icon { get; set; } = string.Empty;
        public string IconColor { get; set; } = string.Empty;
        public string TimeAgo => GetTimeAgo();

        private string GetTimeAgo()
        {
            var timeSpan = DateTime.UtcNow - Timestamp;

            if (timeSpan.TotalMinutes < 1) return "just now";
            if (timeSpan.TotalMinutes < 60) return $"{(int)timeSpan.TotalMinutes} minutes ago";
            if (timeSpan.TotalHours < 24) return $"{(int)timeSpan.TotalHours} hours ago";
            return $"{(int)timeSpan.TotalDays} days ago";
        }
    }
}