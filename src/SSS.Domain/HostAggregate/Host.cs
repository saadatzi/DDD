using SSS.Domain.Common.Dinner.ValueObjects;
using SSS.Domain.Common.Models;
using SSS.Domain.Host.ValueObjects;
using SSS.Domain.Menu.ValueObjects;

namespace SSS.Domain.Host;

public class Host : AggregateRoot<HostId, string>
{
    private List<MenuId> _menuIds;
    private List<DinnerId> _dinnerIds;

    private Host(HostId id, string name)
        : base(id)
    {
        Name = name;
    }

    public IReadOnlyList<MenuId> MenuIds => _menuIds ??= [];

    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds ??= [];

    public string Name { get; }

    public static Host Create(HostId id, string name) => new Host(id, name);
}