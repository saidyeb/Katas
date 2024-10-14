namespace Payment.Bankings;

public class BankAccount(Ulid id, Money balance, User owner)
{
    public Ulid Id { get; init; } = id;
    public Money Balance { get; init; } = balance;
    public User Owner { get; init; } = owner;
}