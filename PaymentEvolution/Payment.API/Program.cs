using System.Reflection;
using Payment.API.Queries.PaymentCashIn;
using Payment.PaymentMethodCashIns;
using Payment.Registry;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.ExampleFilters();
}).AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

builder.Services.AddPaymentServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/{paymentMethodType}/payment/{BankAccountId}/cashIn", (PaymentCashInRequest request, IPaymentCashInFacade paymentCashIn) =>
{
    paymentCashIn.CashInPayment(request.PaymentMethodType, request.Currency, request.Amount, request.BankAccountId);

    return Results.Created();
})
    .WithName("PostCashInPayment")
    .WithOpenApi();

app.Run();