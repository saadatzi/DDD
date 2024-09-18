using SSS.Domain.Common.Dinner.ValueObjects;
using SSS.Domain.Common.Models;
using SSS.Domain.DinnerAggregate.Entity;
using SSS.Domain.Host.ValueObjects;
using SSS.Domain.Menu.ValueObjects;

namespace SSS.Domain.DinnerAggregate;

public class Dinner : AggregateRoot<DinnerId, Guid>
{
    private List<Reservation> _reservations;

    public Dinner()
    {
    }

    private Dinner(
        DinnerId id,
        string name,
        string description,
        List<Reservation> reservations)
        : base(id)
    {
        Name = name;
        Description = description;
        _reservations = reservations;
    }

    public IReadOnlyList<Reservation> Reservations => _reservations ??= [];

    public string Name { get; }

    public string Description { get; }

    public HostId HostId { get; private set; }

    public MenuId MenuId { get; private set; }

    public static Dinner Create(
        DinnerId id,
        string name,
        string description,
        List<Reservation> reservations) => new(
            id,
            name,
            description,
            reservations);
}