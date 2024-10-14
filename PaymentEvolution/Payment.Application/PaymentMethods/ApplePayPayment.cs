using Payment.Bankings;
using Payment.PaymentMethodCashIns;

namespace Payment.Application.PaymentMethods;

public class ApplePayPayment : IPaymentMethod
{
    public void ProcessPayment(Money money, BankAccount bankAccountReceiver)
    {
        //bankAccountReceiver.Balance.AddMoney(money);
    }
}