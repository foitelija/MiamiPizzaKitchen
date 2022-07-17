using Stripe.Checkout;

namespace BlazorMiamiPizza.Server.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<Session> CreateCheckoutSession();
        Task<ServiceResponse<bool>> FullfillOrder(HttpRequest request);
    }
}
