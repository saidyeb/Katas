using Payment.Bankings;
using Payment.PaymentMethodCashIns;

namespace Payment.Application;

public class PaymentCashInFacade(IPaymentMethodFactory paymentMethodFactory) : IPaymentCashInFacade
{
    public void CashInPayment(PaymentMethodType paymentMethodType, Currency currency, decimal amount, Ulid bankAccountReceiverId)
    {
        var paymentMethod = paymentMethodFactory.CreatePaymentMethod(paymentMethodType);
        var money = new Money(currency, amount);
        var bankAccountReceiver = new BankAccount(new Ulid(), money, new User(new Ulid(), "firstname", "lastname"));
        paymentMethod.ProcessPayment(money, bankAccountReceiver);
    }
}