namespace SSS.Domain.MenuReview.ValueObjects;

public class MenuReviewId : ValueObject
{
    private MenuReviewId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static MenuReviewId CreateUnique(Guid value) => new MenuReviewId(value);

    public override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }
}