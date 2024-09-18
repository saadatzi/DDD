using SSS.Domain.Common.Models;
using SSS.Domain.GuestAggregate.ValueObjects;
using SSS.Domain.Host.ValueObjects;
using SSS.Domain.Menu.ValueObjects;
using SSS.Domain.MenuReview.ValueObjects;

namespace SSS.Domain.MenuReview;

public class MenuReview : AggregateRoot<MenuReviewId, Guid>
{
    private MenuReview()
    {
    }

    private MenuReview(
        MenuReviewId id,
        MenuId menuId,
        HostId hostId,
        GuestId guestId)
        : base(id)
    {
        MenuId = menuId;
        HostId = hostId;
        GuestId = guestId;
    }

    public MenuId MenuId { get; protected set; }

    public HostId HostId { get; protected set; }

    public GuestId GuestId { get; protected set; }

    public static MenuReview Create(
        MenuReviewId id,
        MenuId menuId,
        HostId hostId,
        GuestId guestId) => new MenuReview(
            id,
            menuId,
            hostId,
            guestId);
}