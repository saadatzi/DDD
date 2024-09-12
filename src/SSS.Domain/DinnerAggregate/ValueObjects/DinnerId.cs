using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSS.Domain.Common.Dinner.ValueObjects;

public class DinnerId : ValueObject
{
    private DinnerId()
    {
    }

    private DinnerId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; private set; }

    public static DinnerId CreateUnique(Guid value) => new DinnerId(value);

    public override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }
}