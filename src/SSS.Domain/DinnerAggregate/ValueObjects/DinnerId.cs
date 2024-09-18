using SSS.Domain.Common.Models;

namespace SSS.Domain.Common.Dinner.ValueObjects;

public class DinnerId : AggregateRootId<Guid>
{
    private DinnerId()
    {
    }

    private DinnerId(Guid value)
    {
        Value = value;
    }

    public override Guid Value { get; protected set; }

    public static DinnerId CreateUnique()
    {
        return new DinnerId(Guid.NewGuid());
    }

    public static DinnerId Create(Guid value) => new DinnerId(value);

    public override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }
}