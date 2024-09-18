using SSS.Domain.Common.Models;

namespace SSS.Domain.MenuReview.ValueObjects;

public class MenuReviewId : AggregateRootId<Guid>
{
    private MenuReviewId()
    {
    }

    private MenuReviewId(Guid value)
    {
        Value = value;
    }

    public override Guid Value { get; protected set; }

    public static MenuReviewId CreateUnique() => new MenuReviewId(Guid.NewGuid());

    public static MenuReviewId Create(Guid value) => new MenuReviewId(value);

    public override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }
}