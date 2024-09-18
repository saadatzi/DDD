using SSS.Domain.Common.Models;

namespace SSS.Domain.BillAggregate.ValueObjects;

public class BillId : AggregateRootId<Guid>
{
    public BillId()
    {
    }

    public BillId(Guid value)
    {
        Value = value;
    }

    public override Guid Value { get; protected set; }

    public static BillId CreateUnique()
    {
        return new BillId(Guid.NewGuid());
    }

    public static BillId Create(Guid value) => new BillId(value);

    public override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }
}