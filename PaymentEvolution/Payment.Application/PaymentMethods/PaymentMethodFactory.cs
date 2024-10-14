using Microsoft.Extensions.DependencyInjection;
using Payment.PaymentMethodCashIns;

namespace Payment.Application.PaymentMethods;

public class PaymentMethodFactory(IServiceProvider serviceProvider) : IPaymentMethodFactory
{
    private readonly Dictionary<PaymentMethodType, Func<IPaymentMethod>> _paymentMethods = new ()
    {
        { PaymentMethodType.ApplePay, serviceProvider.GetRequiredService<ApplePayPayment> },
        { PaymentMethodType.DoublePayment, serviceProvider.GetRequiredService<DoublePayment> },
        { PaymentMethodType.GooglePay, serviceProvider.GetRequiredService<GooglePayPayment> }
    };
        
    public IPaymentMethod CreatePaymentMethod(PaymentMethodType paymentMethodType)
    {
        if(!_paymentMethods.TryGetValue(paymentMethodType, out var paymentMethod))
            throw new ArgumentException($"Unsupported payment method: {paymentMethodType}");

        return paymentMethod.Invoke();
    }
}