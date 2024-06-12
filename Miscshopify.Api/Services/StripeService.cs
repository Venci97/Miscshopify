using Microsoft.Extensions.Options;
using Miscshopify.Api.Configurations;
using Stripe;
using System.Threading.Tasks;

namespace Miscshopify.Api
{
    public class StripeService
    {
        private readonly StripeSettings _stripeSettings;

        public StripeService(IOptions<StripeSettings> stripeSettings)
        {
            _stripeSettings = stripeSettings.Value;
            StripeConfiguration.ApiKey = _stripeSettings.SecretKey;
        }

        public async Task<Charge> CreateCharge(string token, decimal amount, string currency)
        {
            var options = new ChargeCreateOptions
            {
                Amount = (long)(amount * 100), // Amount in cents
                Currency = currency,
                Description = "Test Charge",
                Source = token,
            };

            var service = new ChargeService();
            Charge charge = await service.CreateAsync(options);
            return charge;
        }
    }
}
