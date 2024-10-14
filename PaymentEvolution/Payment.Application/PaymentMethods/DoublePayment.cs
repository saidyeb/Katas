using Payment.Bankings;
using Payment.PaymentMethodCashIns;

namespace Payment.Application.PaymentMethods;

public class DoublePayment(IPaymentMethodFactory paymentMethodFactory) : IPaymentMethod
{
    private readonly IPaymentMethod _applePayPaymentMethod = paymentMethodFactory.CreatePaymentMethod(PaymentMethodType.ApplePay);
    private readonly IPaymentMethod _googlePayPaymentMethod = paymentMethodFactory.CreatePaymentMethod(PaymentMethodType.GooglePay);
    
    public void ProcessPayment(Money money, BankAccount bankAccountReceiver)
    {
        _applePayPaymentMethod.ProcessPayment(money, bankAccountReceiver);
        _googlePayPaymentMethod.ProcessPayment(money, bankAccountReceiver);
    }
}