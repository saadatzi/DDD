using SSS.Domain.Common.Models;

namespace SSS.Domain.GuestAggregate.ValueObjects;

public class GuestRatingId : AggregateRootId<Guid>
{
    public GuestRatingId()
    {
    }

    public GuestRatingId(Guid value)
    {
        Value = value;
    }

    public override Guid Value { get; protected set; }

    public static GuestRatingId CreateUnique() => new(Guid.NewGuid());

    public static GuestRatingId Create(Guid value) => new(value);

    public override IEnumerable<object> GetEqualityComponent()
    {
        throw new NotImplementedException();
    }
}