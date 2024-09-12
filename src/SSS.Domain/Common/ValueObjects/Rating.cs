using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSS.Domain.Common.ValueObjects;

public class Rating : ValueObject
{
    private Rating()
    {
    }

    private Rating(double value)
    {
        Value = value;
    }

    public double Value { get; }

    public static Rating Create(double value) => new(value);

    public override IEnumerable<object> GetEqualityComponent()
    {
        throw new NotImplementedException();
    }
}