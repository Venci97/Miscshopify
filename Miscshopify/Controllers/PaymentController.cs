using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Miscshopify.Core.Contracts;
using Miscshopify.Infrastructure.Data.Models.Enums;
using Stripe;
using System;
using System.Collections.Generic;
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
            ViewBag.PaymentMethod = paymentMethod ?? "Card";
            ViewBag.PublishableKey = _configuration["Stripe:PublishableKey"];

            return View();
        }

        [HttpGet]
        public IActionResult CreatePaymentIntent(decimal totalPrice, string paymentMethod)
        {
            return RedirectToAction(nameof(CreatePayment), new { totalPrice, paymentMethod });
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> CreatePaymentIntent([FromBody] CreatePaymentIntentRequest request)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(userId))
                {
                    return BadRequest(new { error = "Потребителят не е намерен. Моля влезте отново." });
                }

                if (request == null || request.Amount <= 0)
                {
                    return BadRequest(new { error = "Невалидна сума за плащане." });
                }

                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)Math.Round(request.Amount * 100),
                    Currency = "eur",
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

                _logger.LogInformation("PaymentIntent successfully created: {IntentId} for user {UserId}", intent.Id, userId);

                return Ok(new { clientSecret = intent.ClientSecret });
            }
            catch (StripeException ex)
            {
                _logger.LogError(ex, "Stripe error during PaymentIntent creation: {Message}", ex.Message);
                return BadRequest(new { error = ex.StripeError?.Message ?? "Грешка от Stripe при инициализация." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "General error during PaymentIntent creation");
                return StatusCode(500, new { error = "Възникна сървърна грешка. Моля опитайте отново." });
            }
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> ConfirmOrder([FromBody] ConfirmOrderRequest request)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(userId))
                {
                    return Json(new { success = false, error = "Потребителят не е намерен." });
                }

                if (request == null || string.IsNullOrEmpty(request.PaymentIntentId))
                {
                    return Json(new { success = false, error = "Невалидни данни за плащане." });
                }

                var service = new PaymentIntentService();
                var intent = await service.GetAsync(request.PaymentIntentId);

                if (intent.Status != "succeeded")
                {
                    _logger.LogWarning("PaymentIntent {IntentId} is not succeeded. Status: {Status}", intent.Id, intent.Status);
                    return Json(new { success = false, error = $"Плащането не е потвърдено. Статус: {intent.Status}" });
                }

                PaymentMethodEnum paymentMethodEnum = request.PaymentMethod == "Card"
                    ? PaymentMethodEnum.Card
                    : PaymentMethodEnum.CashOnDelivery;

                await _orderService.CompleteOrder(userId, paymentMethodEnum);

                _logger.LogInformation("Order completed for user {UserId}, PaymentIntent {IntentId}", userId, intent.Id);

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
                _logger.LogError(ex, "Stripe error during order confirmation");
                return Json(new { success = false, error = ex.StripeError?.Message ?? "Грешка при потвърждение." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "General error during order confirmation");
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