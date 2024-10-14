using Payment.Bankings;

namespace Payment.PaymentMethodCashIns;

public interface IPaymentMethod
{
    void ProcessPayment(Money money, BankAccount bankAccountReceiver);
}