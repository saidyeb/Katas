namespace Payment.Bankings;

public class User(Ulid id, string firstName, string lastName)
{
    public Ulid Id { get; init; } = id;
    public string FirstName { get; init; } = firstName;
    public string LastName { get; init; } = lastName;
}