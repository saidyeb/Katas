using Microsoft.Extensions.DependencyInjection;
using Payment.Application;
using Payment.Application.PaymentMethods;
using Payment.PaymentMethodCashIns;

namespace Payment.Registry;

public static class PaymentService
{
    public static void AddPaymentServices(this IServiceCollection  serviceCollection)
    {
        serviceCollection.AddScoped<IPaymentMethodFactory, PaymentMethodFactory>()
            .AddScoped<IPaymentCashInFacade, PaymentCashInFacade>()
            .AddScoped<ApplePayPayment>()
            .AddScoped<GooglePayPayment>()
            .AddScoped<DoublePayment>();
    }
}