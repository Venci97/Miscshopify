using Miscshopify.Api.Configurations;
using Miscshopify.Infrastructure.Data.Models;
using Stripe.Checkout;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Miscshopify.Api
{
    public class StripeService
    {
        private readonly StripeSettings _stripeSettings;

        public StripeService(StripeSettings stripeSettings)
        {
            _stripeSettings = stripeSettings;
            Stripe.StripeConfiguration.ApiKey = _stripeSettings.SecretKey;
        }

        public async Task<string> CreateCheckoutSessionFromCartAsync(IEnumerable<CartItem> cartItems, decimal totalAmount, string successUrl, string cancelUrl)
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "bgn",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "Cart Items"
                            },
                            UnitAmount = (long)(totalAmount * 100) // BGN
                        },
                        Quantity = 1
                    }
                },
                Mode = "payment",
                SuccessUrl = successUrl,
                CancelUrl = cancelUrl
            };

            var service = new SessionService();
            var session = await service.CreateAsync(options);
            return session.Url;
        }
    }
}
