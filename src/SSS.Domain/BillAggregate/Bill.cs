using SSS.Domain.BillAggregate.ValueObjects;
using SSS.Domain.Common.Dinner.ValueObjects;

using SSS.Domain.Common.Models;
using SSS.Domain.GuestAggregate.ValueObjects;
using SSS.Domain.Host.ValueObjects;

namespace SSS.Domain.BillAggregate;

public class Bill : AggregateRoot<BillId, Guid>
{
    public Bill()
    {
    }

    public string Amount { get; private set; }

    public string Currency { get; private set; }

    public BillStatus Status { get; private set; }

    public HostId HostId { get; private set; }

    public GuestId GuestId { get; private set; }

    public DinnerId DinnerId { get; private set; }
}