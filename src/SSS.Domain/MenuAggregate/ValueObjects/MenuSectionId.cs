using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSS.Domain.Menu.ValueObjects;

public class MenuSectionId : ValueObject
{
    private MenuSectionId()
    {
    }

    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    // public static MenuSectionId New() => new MenuSectionId(Guid.NewGuid()); // another lambda function approach
    public static MenuSectionId CreateUnique()
    {
        return new MenuSectionId(Guid.NewGuid());
    }

    public static MenuSectionId Create(Guid value) => new(value);

    public override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }
}