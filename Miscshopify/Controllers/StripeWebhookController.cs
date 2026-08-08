using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Miscshopify.Core.Contracts;
using Stripe;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Miscshopify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeWebhookController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IConfiguration _configuration;

        public StripeWebhookController(IOrderService orderService, IConfiguration configuration)
        {
            _orderService = orderService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Index()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            try
            {
                var webhookSecret = _configuration["Stripe:WebhookSecret"];

                var stripeEvent = EventUtility.ConstructEvent(
                    json,
                    Request.Headers["Stripe-Signature"],
                    webhookSecret
                );

                if (stripeEvent.Type == EventTypes.CheckoutSessionCompleted)
                {
                    var session = stripeEvent.Data.Object as Stripe.Checkout.Session;
                    if (session != null && session.Metadata.ContainsKey("OrderId"))
                    {
                        var orderId = session.Metadata["OrderId"];
                        await _orderService.MarkOrderAsPaidAsync(orderId);
                    }
                }

                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest();
            }
        }
    }
}