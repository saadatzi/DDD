using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSS.Domain.Common.Models;

public abstract class AggregateRootId<TId> : ValueObject
{
    public abstract TId Value { get; protected set; }
}