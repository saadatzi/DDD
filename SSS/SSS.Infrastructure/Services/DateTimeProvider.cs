using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SSS.Application.Common.Interfaces.Services;

namespace SSS.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
