using SSS.Domain.BillAggregate.ValueObjects;
using SSS.Domain.Common.Dinner.ValueObjects;

using SSS.Domain.Common.Models;
using SSS.Domain.DinnerAggregate.ValueObjects;
using SSS.Domain.GuestAggregate.ValueObjects;

namespace SSS.Domain.DinnerAggregate.Entity;

public class Reservation : Entity<ReservationId>
{
    private Reservation()
    {
    }

    public DinnerId DinnerId { get; set; }

    public BillId BillId { get; set; }

    public GuestId GuestId { get; set; }
}