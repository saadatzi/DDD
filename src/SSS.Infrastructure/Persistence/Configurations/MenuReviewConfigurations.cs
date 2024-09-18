using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SSS.Domain.MenuReview;
using SSS.Domain.MenuReview.ValueObjects;

namespace SSS.Infrastructure.Persistence.Configurations;

public class MenuReviewConfigurations : IEntityTypeConfiguration<MenuReview>
{
    public void Configure(EntityTypeBuilder<MenuReview> builder)
    {
        ConfigureMenuReviewsTable(builder);
    }

    private void ConfigureMenuReviewsTable(EntityTypeBuilder<MenuReview> builder)
    {
        builder.ToTable("MenuReviews");

        builder.HasKey(mr => mr.Id);

        builder.Property(mr => mr.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuReviewId.Create(value));

        builder.Property(mr => mr.MenuId);

        builder.Property(mr => mr.HostId);

        builder.Property(mr => mr.GuestId);
    }
}