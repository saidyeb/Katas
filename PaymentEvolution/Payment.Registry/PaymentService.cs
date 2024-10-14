using Microsoft.Extensions.DependencyInjection;
using Payment.Application;
using Payment.Application.PaymentMethods;
using Payment.PaymentMethodCashIns;

namespace Payment.Registry;

public static class PaymentService
{
    public static void AddPaymentServices(this IServiceCollection  serviceCollection)
    {
        serviceCollection.AddSingleton<IPaymentMethodFactory, PaymentMethodFactory>()
            .AddScoped<IPaymentCashInFacade, PaymentCashInFacade>()
            .AddScoped<IPaymentMethod, ApplePayPayment>()
            .AddScoped<IPaymentMethod, GooglePayPayment>()
            .AddScoped<IPaymentMethod, DoublePayment>();
    }
}