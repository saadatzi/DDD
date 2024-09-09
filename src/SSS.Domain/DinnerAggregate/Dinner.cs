using SSS.Domain.Common.Dinner.ValueObjects;
using SSS.Domain.Common.Models;

namespace SSS.Domain.Common.Dinner;

public class Dinner : AggregateRoot<DinnerId>
{
    private Dinner(DinnerId id, string name, string description)
        : base(id)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; }

    public string Description { get; }

    public static Dinner Create(DinnerId id, string name, string description) => new(id, name, description);
}