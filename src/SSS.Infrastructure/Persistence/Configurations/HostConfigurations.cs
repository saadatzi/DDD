using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SSS.Domain.Host;
using SSS.Domain.Host.ValueObjects;

namespace SSS.Infrastructure.Persistence.Configurations;

public class HostConfigurations : IEntityTypeConfiguration<Host>
{
    public void Configure(EntityTypeBuilder<Host> builder)
    {
        ConfigureHostTable(builder);
        ConfigureHostMenuIdsTable(builder);
        ConfigureHostDinnerIdsTable(builder);
    }

    private static void ConfigureHostTable(EntityTypeBuilder<Host> builder)
    {
        builder.ToTable("Hosts");

        builder.HasKey(h => h.Id);

        builder.Property(h => h.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));

        builder.Property(h => h.Name)
            .HasMaxLength(100);
    }

    private static void ConfigureHostMenuIdsTable(EntityTypeBuilder<Host> builder)
    {
        builder.OwnsMany(h => h.MenuIds, mib =>
        {
            mib.WithOwner().HasForeignKey("HostId");

            mib.ToTable("HostMenuIds");

            mib.HasKey("Id");

            mib.Property(mi => mi.Value)
                .ValueGeneratedNever()
                .HasColumnName("HostMenuId");
        });

        builder.Metadata.FindNavigation(nameof(Host.MenuIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureHostDinnerIdsTable(EntityTypeBuilder<Host> builder)
    {
        builder.OwnsMany(h => h.DinnerIds, dib =>
        {
            dib.WithOwner().HasForeignKey("HostId");

            dib.ToTable("HostDinnerIds");

            dib.HasKey("Id");

            dib.Property(di => di.Value)
                .ValueGeneratedNever()
                .HasColumnName("HostDinnerId");
        });

        builder.Metadata.FindNavigation(nameof(Host.DinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}