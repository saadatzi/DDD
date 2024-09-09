using SSS.Application.Common.Interfaces.Services;

namespace SSS.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}