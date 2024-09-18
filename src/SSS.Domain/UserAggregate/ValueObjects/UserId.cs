namespace SSS.Domain.User.ValueObjects;

public class UserId : ValueObject
{
    public UserId()
    {
    }

    private UserId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static UserId CreateUnique() => new(Guid.NewGuid());

    public static UserId Create(Guid value) => new(value);

    public override IEnumerable<object> GetEqualityComponent()
    {
        throw new NotImplementedException();
    }
}