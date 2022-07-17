using Stripe.Checkout;

namespace BlazorMiamiPizza.Server.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<Session> CreateCheckoutSession();
    }
}
