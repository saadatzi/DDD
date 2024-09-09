namespace SSS.Domain.Menu.ValueObjects;

public class MenuId : ValueObject
{
    private MenuId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    // public static MenuId New() => new MenuId(Guid.NewGuid()); // another lambda function approach
    public static MenuId CreateUnique()
    {
        return new MenuId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }
}