using SSS.Domain.Common.Dinner.ValueObjects;

using SSS.Domain.Common.Models;
using SSS.Domain.Common.ValueObjects;
using SSS.Domain.GuestAggregate.Enums;
using SSS.Domain.GuestAggregate.ValueObjects;
using SSS.Domain.Host.ValueObjects;

namespace SSS.Domain.GuestAggregate.Entities;

public class GuestRating : AggregateRoot<GuestRatingId, Guid>
{
    public GuestRating()
    {
    }

    public GuestRating(
        GuestRatingId id,
        DinnerId dinnerId,
        HostId hostId,
        RatingScore ratingScore)
        : base(id)
    {
        DinnerId = dinnerId;
        HostId = hostId;
        RatingScore = ratingScore;
    }

    public DinnerId DinnerId { get; private set; }

    public HostId HostId { get; private set; }

    public RatingScore RatingScore { get; private set; }

    public static GuestRating Create(
        DinnerId dinnerId,
        HostId hostId,
        RatingScore ratingScore)
    {
        return new GuestRating(
            GuestRatingId.CreateUnique(),
            dinnerId,
            hostId,
            ratingScore);
    }
}