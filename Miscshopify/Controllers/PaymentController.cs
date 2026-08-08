using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Miscshopify.Core.Contracts;
using Miscshopify.Infrastructure.Data.Models.Enums;
using Stripe;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Miscshopify.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IOrderService _orderService;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(
            IConfiguration configuration,
            IOrderService orderService,
            ILogger<PaymentController> logger)
        {
            _configuration = configuration;
            _orderService = orderService;
            _logger = logger;

            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
        }

        [HttpGet]
        public IActionResult CreatePayment(decimal totalPrice, string paymentMethod)
        {
            ViewBag.TotalPrice = totalPrice;
            ViewBag.PaymentMethod = paymentMethod;
            ViewBag.PublishableKey = _configuration["Stripe:PublishableKey"];

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePaymentIntent([FromBody] CreatePaymentIntentRequest request)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(userId))
                {
                    return Json(new { error = "Потребителят не е намерен. Моля влезте отново." });
                }

                if (request.Amount <= 0)
                {
                    return Json(new { error = "Невалидна сума." });
                }

                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)(request.Amount * 100),
                    Currency = "bgn",
                    AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                    {
                        Enabled = true,
                    },
                    Metadata = new Dictionary<string, string>
                    {
                        ["user_id"] = userId,
                        ["payment_method"] = request.PaymentMethod ?? "Card",
                        ["order_date"] = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
                    }
                };

                var service = new PaymentIntentService();
                var intent = await service.CreateAsync(options);

                _logger.LogInformation("PaymentIntent създаден: {IntentId} за потребител {UserId}", intent.Id, userId);

                return Json(new { clientSecret = intent.ClientSecret });
            }
            catch (StripeException ex)
            {
                _logger.LogError(ex, "Stripe грешка при създаване на PaymentIntent");
                return Json(new { error = ex.StripeError?.Message ?? "Грешка при инициализация на плащането." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Обща грешка при създаване на PaymentIntent");
                return Json(new { error = "Възникна грешка. Моля опитайте отново." });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmOrder([FromBody] ConfirmOrderRequest request)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(userId))
                {
                    return Json(new { success = false, error = "Потребителят не е намерен." });
                }

                var service = new PaymentIntentService();
                var intent = await service.GetAsync(request.PaymentIntentId);

                if (intent.Status != "succeeded")
                {
                    _logger.LogWarning("PaymentIntent {IntentId} не е succeeded. Статус: {Status}", intent.Id, intent.Status);
                    return Json(new { success = false, error = $"Плащането не е потвърдено. Статус: {intent.Status}" });
                }

                PaymentMethodEnum paymentMethodEnum = request.PaymentMethod == "Card"
                    ? PaymentMethodEnum.Card
                    : PaymentMethodEnum.CashOnDelivery;

                await _orderService.CompleteOrder(userId, paymentMethodEnum);

                _logger.LogInformation("Поръчка създадена за потребител {UserId}, PaymentIntent {IntentId}", userId, intent.Id);

                return Json(new
                {
                    success = true,
                    redirectUrl = Url.Action("PaymentSuccess", "Payment", new
                    {
                        orderId = intent.Id,
                        amount = request.Amount,
                        paymentMethod = request.PaymentMethod
                    })
                });
            }
            catch (StripeException ex)
            {
                _logger.LogError(ex, "Stripe грешка при потвърждение на поръчка");
                return Json(new { success = false, error = ex.StripeError?.Message ?? "Грешка при потвърждение." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Обща грешка при потвърждение на поръчка");
                return Json(new { success = false, error = "Възникна грешка при записване на поръчката." });
            }
        }

        [HttpGet]
        public IActionResult PaymentSuccess(string orderId, decimal amount, string paymentMethod)
        {
            ViewBag.OrderId = orderId;
            ViewBag.Amount = amount;
            ViewBag.PaymentMethod = paymentMethod;
            return View();
        }
    }

    public class CreatePaymentIntentRequest
    {
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
    }

    public class ConfirmOrderRequest
    {
        public string PaymentIntentId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
