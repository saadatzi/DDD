namespace SSS.Domain.Common.Models;

public abstract class Entity<TId> : IEquatable<Entity<TId>>, IHasDomainEvents
    where TId : notnull
{
    private List<IDomainEvent> _domainEvents;

    protected Entity()
    {
    }

    protected Entity(TId id)
    {
        Id = id;
    }

    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents ??= [];

    public TId Id { get; protected set; }

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return Equals(left, right);
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && Id.Equals(entity.Id);
    }

    public bool Equals(Entity<TId>? other)
    {
        throw new NotImplementedException();
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}