using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SSS.Domain.BillAggregate;
using SSS.Domain.BillAggregate.ValueObjects;
using SSS.Domain.Common.Dinner.ValueObjects;
using SSS.Domain.GuestAggregate.ValueObjects;
using SSS.Domain.Host.ValueObjects;

namespace SSS.Infrastructure.Persistence.Configurations;

public class BillConfigurations : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        ConfigureBillsTable(builder);
    }

    private void ConfigureBillsTable(EntityTypeBuilder<Bill> builder)
    {
        builder.ToTable("Bills");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => BillId.Create(value));

        builder.Property(b => b.Currency)
            .HasMaxLength(20);

        builder.Property(b => b.Status)
            .HasDefaultValue("Pending");

        builder.Property(m => m.HostId)
            .HasMaxLength(200)
            .ValueGeneratedNever() // since dbcontext tries to generate value for id, we need to stop it.
            .HasConversion(
                id => id!.Value,
                value => HostId.Create(value));

        builder.Property(m => m.GuestId)
            .HasMaxLength(200)
            .ValueGeneratedNever() // since dbcontext tries to generate value for id, we need to stop it.
            .HasConversion(
                id => id!.Value,
                value => GuestId.Create(value));

        builder.Property(m => m.DinnerId)
            .HasMaxLength(200)
            .ValueGeneratedNever() // since dbcontext tries to generate value for id, we need to stop it.
            .HasConversion(
                id => id!.Value,
                value => DinnerId.Create(value));
    }
}