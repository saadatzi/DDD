using SSS.Domain.BillAggregate.ValueObjects;

using SSS.Domain.Common.Dinner.ValueObjects;

using SSS.Domain.Common.Models;
using SSS.Domain.GuestAggregate.Entities;
using SSS.Domain.GuestAggregate.ValueObjects;
using SSS.Domain.MenuReview.ValueObjects;
using SSS.Domain.User.ValueObjects;

namespace SSS.Domain.GuestAggregate;

public class Guest : AggregateRoot<GuestId, Guid>
{
    private List<DinnerId> _dinnerIds;

    private List<BillId> _billIds;

    private List<GuestRating> _guestRatings;
    private List<MenuReviewId> _menuReviewIds;

    private Guest()
    {
    }

    private Guest(GuestId id, UserId userId)
        : base(id)
    {
        UserId = userId;
    }

    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds ??= [];

    public IReadOnlyList<BillId> BillIds => _billIds ??= [];

    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds ??= [];

    public IReadOnlyList<GuestRating> GuestRatings => _guestRatings ??= [];

    public UserId UserId { get; }

    public static Guest Create(
        GuestId id,
        UserId userId)
    {
        return new Guest(id, userId);
    }
}