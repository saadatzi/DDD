using SSS.Domain.Common.Models;

namespace SSS.Domain.GuestAggregate.ValueObjects;

public class GuestId : AggregateRootId<Guid>
{
    public GuestId()
    {
    }

    public GuestId(Guid value)
    {
        Value = value;
    }

    public override Guid Value { get; protected set; }

    public static GuestId CreateUnique()
    {
        return new GuestId(Guid.NewGuid());
    }

    public static GuestId Create(Guid value) => new GuestId(value);

    public override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }
}