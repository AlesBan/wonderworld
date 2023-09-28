using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Persistence.EntityConnectionsConfiguration;

public class EstablishmentTypeEstablishmentConfiguration : IEntityTypeConfiguration<EstablishmentTypeEstablishment>
{
    public void Configure(EntityTypeBuilder<EstablishmentTypeEstablishment> builder)
    {
        builder.HasKey(e => new { e.EstablishmentTypeId, e.EstablishmentId });
        builder.HasIndex(e => new { e.EstablishmentTypeId, e.EstablishmentId })
            .IsUnique();

        builder.HasOne(e => e.EstablishmentType)
            .WithMany(e => e.EstablishmentTypes)
            .HasForeignKey(e => e.EstablishmentTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Establishment)
            .WithMany(e => e.EstablishmentTypes)
            .HasForeignKey(e => e.EstablishmentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}