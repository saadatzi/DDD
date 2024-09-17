namespace SSS.Domain.Common.Models;

public abstract class AggregateRoot<TId, TIdType> : Entity<TId>
    where TId : AggregateRootId<TIdType>
{
    protected AggregateRoot()
    {
    }

    protected AggregateRoot(TId id)
    {
        Id = id;
    }

    public new AggregateRootId<TIdType> Id { get; protected set; }
}