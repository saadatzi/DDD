using SSS.Domain.Common.Models;

namespace SSS.Domain.Menu.ValueObjects;

public class MenuId : AggregateRootId<Guid>
{
    private MenuId()
    {
    }

    private MenuId(Guid value)
    {
        Value = value;
    }

    public override Guid Value { get; protected set; }

    // public static MenuId New() => new MenuId(Guid.NewGuid()); // another lambda function approach
    public static MenuId CreateUnique()
    {
        // TODO: enforce invariants
        return new MenuId(Guid.NewGuid());
    }

    public static MenuId Create(Guid value)
    {
        // TODO: enforce invariants
        return new MenuId(value);
    }

    public override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }
}