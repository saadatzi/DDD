namespace SSS.Domain.Host.ValueObjects;

public class HostId : ValueObject
{
    private HostId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static HostId CreateUnique(Guid value) => new HostId(value);

    public override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }
}