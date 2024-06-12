using Microsoft.AspNetCore.Mvc;
using Miscshopify.Api;
using Miscshopify.Controllers;
using Miscshopify.Infrastructure.Data.Models.Enums;
using Stripe;
using System.Threading.Tasks;

namespace Miscshopify.Web.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly StripeService _stripeService;

        public PaymentController(StripeService stripeService)
        {
            _stripeService = stripeService;
        }

        [HttpGet]
        public IActionResult CreatePayment(decimal totalPrice, PaymentMethodEnum paymentMethod)
        {
            ViewBag.TotalPrice = totalPrice;
            ViewBag.PaymentMethod = paymentMethod;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePayment(string stripeToken, decimal amount, PaymentMethodEnum paymentMethod)
        {
            try
            {
                var options = new ChargeCreateOptions
                {
                    Amount = (long)(amount * 100), // Convert amount to cents
                    Currency = "bgn",
                    Description = "Order Payment",
                    Source = stripeToken
                };

                var service = new ChargeService();
                Charge charge = await service.CreateAsync(options);

                return Json(new { success = true, redirectUrl = Url.Action("CompleteOrder", "Order", new { paymentMethod }) });
            }
            catch (StripeException e)
            {
                return Json(new { success = false, message = e.Message });
            }
        }
    }
}
