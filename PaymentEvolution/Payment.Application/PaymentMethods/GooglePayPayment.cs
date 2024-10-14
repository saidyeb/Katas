using Payment.Bankings;
using Payment.PaymentMethodCashIns;

namespace Payment.Application.PaymentMethods;

public class GooglePayPayment : IPaymentMethod
{
    public void ProcessPayment(Money money, BankAccount bankAccountReceiver)
    {
        /*var bankAccountReceiver = new BankAccount(bankAccountReceiverId, new Money())
        bankAccountReceiver.Balance.AddMoney(money);*/
    }
}