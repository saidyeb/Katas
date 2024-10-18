using Payment.API.Queries.PaymentCashIn;
using Payment.Bankings;
using Payment.PaymentMethodCashIns;

namespace Payment.API.Examples;

using Swashbuckle.AspNetCore.Filters;

internal class CashInRequestExample : IExamplesProvider<PaymentCashInRequest>
{
    public PaymentCashInRequest GetExamples()
    {
        return new PaymentCashInRequest
        (
            PaymentMethodType.ApplePay,
            Currency.Mad,
            100.00m,
            Ulid.NewUlid()
        );
    }
}