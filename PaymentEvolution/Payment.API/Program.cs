using Payment.Bankings;
using Payment.PaymentMethodCashIns;
using Payment.Registry;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPaymentServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/{paymentMethodType}/payment/{BankAccountId}/cashIn", (PaymentMethodType paymentMethodType, Currency currency, decimal amount, string bankAccountId) =>
{
    var paymentCashIn = app.Services.GetRequiredService<IPaymentCashInFacade>();
    paymentCashIn.CashInPayment(paymentMethodType, currency, amount, new (new Guid(bankAccountId)));

    return StatusCodes.Status201Created;
})
    .WithName("PostCashInPayment")
    .WithOpenApi();

app.Run();