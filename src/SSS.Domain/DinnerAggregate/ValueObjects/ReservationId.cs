namespace SSS.Domain.DinnerAggregate.ValueObjects;

public class ReservationId : ValueObject
{
    private ReservationId()
    {
    }

    private ReservationId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; protected set; }

    public static ReservationId CreateUnique()
    {
        return new ReservationId(Guid.NewGuid());
    }

    public static ReservationId Create(Guid value) => new ReservationId(value);

    public override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }
}