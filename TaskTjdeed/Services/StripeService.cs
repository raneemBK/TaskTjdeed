using Stripe;

namespace TaskTjdeed.Services
{
    public class StripeService
    {
        private readonly string _secretKey;

        public StripeService(IConfiguration config)
        {
            _secretKey = config["Stripe:SecretKey"];
            StripeConfiguration.ApiKey = _secretKey;
        }

        public async Task<string> CreatePaymentIntent(decimal amount)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(amount * 100), // Amount in cents
                Currency = "usd",
                PaymentMethodTypes = new List<string> { "card" },
            };

            var service = new PaymentIntentService();
            var paymentIntent = await service.CreateAsync(options);

            return paymentIntent.ClientSecret;
        }
    }
}
