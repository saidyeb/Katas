using Payment.Bankings;
using Payment.PaymentMethodCashIns;

namespace Payment.API.Queries.PaymentCashIn;

internal record PaymentCashInRequest(PaymentMethodType PaymentMethodType, Currency Currency, decimal Amount, Ulid BankAccountId);