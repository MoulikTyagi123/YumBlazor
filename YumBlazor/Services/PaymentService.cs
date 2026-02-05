using Stripe.Checkout;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;
using YumBlazor.Utility;
using Microsoft.AspNetCore.Components;

namespace YumBlazor.Services
{
    public class PaymentService
    {
        private readonly NavigationManager _navigationManager;
        private readonly IOrderRepository _orderRepository;

        public PaymentService(NavigationManager navigationManager, IOrderRepository orderRepository)
        {
            _navigationManager = navigationManager;
            _orderRepository = orderRepository;
        }

        public Session CreateStripeCheckoutSession(OrderHeader orderHeader)
        {
            var lineItems = orderHeader.OrderDetails
                .Select(order => new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "inr", // Changed to INR if you are in India, or use "usd"
                        UnitAmountDecimal = (decimal)order.Price * 100, // Stripe expects cents/paise
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = order.ProductName
                        }
                    },
                    Quantity = order.Count
                }).ToList();

            var options = new SessionCreateOptions
            {
                SuccessUrl = $"{_navigationManager.BaseUri}order/success/{{CHECKOUT_SESSION_ID}}",
                CancelUrl = $"{_navigationManager.BaseUri}cart",
                LineItems = lineItems,
                Mode = "payment",
            };

            var service = new SessionService();
            return service.Create(options);
        }

        public async Task<OrderHeader> CheckPaymentStatusAndUpdateOrder(string sessionId)
        {
            OrderHeader orderHeader = await _orderRepository.GetOrderBySessionIdAsync(sessionId);
            var service = new SessionService();
            var session = service.Get(sessionId);

            if (session.PaymentStatus.ToLower() == "paid")
            {
                await _orderRepository.UpdateStatusAsync(
                    orderHeader.Id,
                    SD.StatusApproved,
                    session.PaymentIntentId
                );
            }
            return orderHeader;
        }
    }
}