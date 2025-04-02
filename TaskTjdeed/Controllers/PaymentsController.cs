using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using TaskTjdeed.Services;

namespace TaskTjdeed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PaymentsController(IConfiguration configuration)
        {
            _configuration = configuration;
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
        }

        /// <summary>
        /// Create a payment intent and return the client secret.
        /// </summary>
        [HttpPost("create-payment-intent")]
        public async Task<IActionResult> CreatePaymentIntent([FromBody] decimal amount)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(amount * 100), // Convert amount to cents
                Currency = "usd",
                PaymentMethodTypes = new List<string> { "card" }
            };

            var service = new PaymentIntentService();
            var paymentIntent = await service.CreateAsync(options);

            return Ok(new { clientSecret = paymentIntent.ClientSecret, paymentIntentId = paymentIntent.Id });
        }

        /// <summary>
        /// Confirm a payment intent for testing in Swagger.
        /// </summary>
        [HttpPost("confirm-payment-intent")]
        public async Task<IActionResult> ConfirmPaymentIntent([FromBody] string paymentIntentId)
        {
            var service = new PaymentIntentService();
            var paymentIntent = await service.GetAsync(paymentIntentId);

            if (paymentIntent.Status == "requires_payment_method")
            {
                var confirmOptions = new PaymentIntentConfirmOptions
                {
                    PaymentMethod = "pm_card_visa" // Stripe test card
                };

                var confirmedPaymentIntent = await service.ConfirmAsync(paymentIntentId, confirmOptions);

                return Ok(new { status = confirmedPaymentIntent.Status });
            }

            return BadRequest("PaymentIntent is not in a valid state for confirmation.");
        }
    }
}
