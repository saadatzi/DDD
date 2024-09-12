using SSS.Domain.Menu.Entity;

namespace SSS.Domain.Menu.ValueObjects;

public class MenuItemId : ValueObject
{
    private MenuItemId()
    {
    }

    private MenuItemId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static MenuItemId CreateUnique()
    {
        return new MenuItemId(Guid.NewGuid());
    }

    public static MenuItemId Create(Guid value) => new MenuItemId(value);

    public override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }
}