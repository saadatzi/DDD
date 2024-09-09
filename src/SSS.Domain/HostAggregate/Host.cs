using SSS.Domain.Common.Models;
using SSS.Domain.Host.ValueObjects;

namespace SSS.Domain.Host;

public class Host : AggregateRoot<HostId>
{
    private Host(HostId id, string name)
        : base(id)
    {
        Name = name;
    }

    public string Name { get; }

    public static Host Create(HostId id, string name) => new Host(id, name);
}