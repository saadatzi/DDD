using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SSS.Domain.GuestAggregate;
using SSS.Domain.GuestAggregate.ValueObjects;
using SSS.Domain.User.ValueObjects;

namespace SSS.Infrastructure.Persistence.Configurations;

public class GuestConfigurations : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        ConigureGuestsTable(builder);
        ConigureGuestRatingsTable(builder);
    }

    private void ConigureGuestRatingsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.GuestRatings, grb =>
        {
            grb.ToTable("GuestRatings");

            grb.WithOwner().HasForeignKey("GuestId");

            grb.HasKey("Id", "GuestId");

            grb.Property(gr => gr.Id)
                .HasColumnName("GuestRatingId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => GuestRatingId.Create(value));

            grb.Property(gr => gr.HostId)
                .HasMaxLength(200);

            grb.Property(gr => gr.DinnerId)
                .HasMaxLength(200);

            grb.Property(gr => gr.RatingScore);
        });

        builder.Metadata.FindNavigation(nameof(Guest.GuestRatings))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConigureGuestsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.ToTable("Guests");

        builder.HasKey(g => g.Id);

        builder.Property(g => g.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => GuestId.Create(value));

        builder.Property(g => g.UserId)
            .HasMaxLength(200)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));
    }
}