using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SSS.Domain.BillAggregate.ValueObjects;

using SSS.Domain.Common.Dinner.ValueObjects;
using SSS.Domain.DinnerAggregate;
using SSS.Domain.DinnerAggregate.ValueObjects;
using SSS.Domain.GuestAggregate.ValueObjects;
using SSS.Domain.Host.ValueObjects;
using SSS.Domain.Menu.ValueObjects;

namespace SSS.Infrastructure.Persistence.Configurations;

public class DinnerConfigurations : IEntityTypeConfiguration<Dinner>
{
    public void Configure(EntityTypeBuilder<Dinner> builder)
    {
        ConfigurationDinnerTable(builder);
        ConfigurationDinnerReservationsTable(builder);
    }

    private void ConfigurationDinnerReservationsTable(EntityTypeBuilder<Dinner> builder)
    {
        builder.OwnsMany(d => d.Reservations, rb =>
        {
            rb.ToTable("DinnerReservations");

            rb.HasKey("Id", "DinnerId");

            rb.Property(r => r.Id)
                .HasColumnName("DinnerReservationId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ReservationId.Create(value));

            rb.Property(r => r.BillId)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id!.Value,
                    value => BillId.Create(value));

            rb.Property(r => r.GuestId)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id!.Value,
                    value => GuestId.Create(value));
        });

        builder.Metadata.FindNavigation(nameof(Dinner.Reservations))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigurationDinnerTable(EntityTypeBuilder<Dinner> builder)
    {
        builder.ToTable("Dinners");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => DinnerId.Create(value));

        builder.Property(d => d.Name)
            .HasMaxLength(100);

        builder.Property(d => d.Description)
            .HasMaxLength(100);

        builder.Property(d => d.MenuId)
            .HasMaxLength(100)
            .ValueGeneratedNever()
            .HasConversion(
                id => id!.Value,
                value => MenuId.Create(value));

        builder.Property(d => d.HostId)
            .HasMaxLength(100)
            .ValueGeneratedNever()
            .HasConversion(
                id => id!.Value,
                value => HostId.Create(value));
    }
}