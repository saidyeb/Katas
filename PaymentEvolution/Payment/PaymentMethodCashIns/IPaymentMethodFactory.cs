namespace Payment.PaymentMethodCashIns;

public interface IPaymentMethodFactory
{
    IPaymentMethod CreatePaymentMethod(PaymentMethodType paymentMethodType);
}