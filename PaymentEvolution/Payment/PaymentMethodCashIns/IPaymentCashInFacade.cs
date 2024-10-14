using Payment.Bankings;

namespace Payment.PaymentMethodCashIns;

public interface IPaymentCashInFacade
{
    void CashInPayment(PaymentMethodType paymentMethodType, Currency currency, decimal amount, Ulid bankAccountReceiverId);
}