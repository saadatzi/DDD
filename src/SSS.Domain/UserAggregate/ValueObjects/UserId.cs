using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSS.Domain.User.ValueObjects;

public class UserId : ValueObject
{
    private UserId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static UserId CreateUnique(Guid value) => new(value);

    public override IEnumerable<object> GetEqualityComponent()
    {
        throw new NotImplementedException();
    }
}