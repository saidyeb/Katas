namespace Payment.Bankings;

public struct Money : IEquatable<Money>, IComparable<Money>
{
    public Currency Currency { get; init; }
    public decimal Amount { get; private set; }

    public Money(Currency currency, decimal amount)
    {
        Currency = currency;
        Amount = amount;
    }

    public void AddMoney(Money money)
    {
        ThrowIfCurrencyUnauthorized(money.Currency);
        ThrowIfAmountIsNegative(money.Amount);
        
        Amount += money.Amount;
    }
    
    public void WithdrawMoney(Money money)
    {
        ThrowIfCurrencyUnauthorized(money.Currency);
        ThrowIfAmountIsNegative(money.Amount);
        ThrowIfBalanceIsInsufficient(money.Amount);
        
        Amount -= money.Amount;
    }

    public bool Equals(Money money) => CompareTo(money) == 0;
    
    

    public int CompareTo(Money money)
    {
        if (Currency.CompareTo(money.Currency) != 0) 
            throw new ArgumentException("Cannot compare Money with different currencies");

        return Amount.CompareTo(money.Amount);
    }

    public static bool operator ==(Money left, Money right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Money left, Money right)
    {
        return !(left == right);
    }
    
    private void ThrowIfCurrencyUnauthorized(Currency currency)
    {
        if(Currency.Equals(currency)) throw new InvalidOperationException("Cannot withdraw with different currency.");
    }

    private static void ThrowIfAmountIsNegative(decimal amount)
    {
        if (amount.CompareTo(double.NegativeZero) < 0) throw new ArgumentException("Cannot withdraw with negative amount.");
    }

    private void ThrowIfBalanceIsInsufficient(decimal amount)
    {
        if (amount.CompareTo(Amount) > 0) throw new InvalidOperationException("Insufficient funds.");
    }
}