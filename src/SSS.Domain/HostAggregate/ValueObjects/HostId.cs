using SSS.Domain.User.ValueObjects;

namespace SSS.Domain.Host.ValueObjects;

public class HostId : ValueObject
{
    private HostId(string value)
    {
        Value = value;
    }

    private HostId()
    {
        Value = $"{Guid.NewGuid()}";
    }

    public string Value { get; private set; }

    public static HostId CreateUnique() => new();

    public static HostId Create(UserId userId) => new HostId($"Host_{userId.Value}");

    public static HostId Create(string hostId) => new HostId(hostId);

    public override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }
}