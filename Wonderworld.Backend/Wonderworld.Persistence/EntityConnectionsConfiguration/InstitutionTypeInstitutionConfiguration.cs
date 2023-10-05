using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Persistence.EntityConnectionsConfiguration;

public class InstitutionTypeInstitutionConfiguration : IEntityTypeConfiguration<InstitutionTypeInstitution>
{
    public void Configure(EntityTypeBuilder<InstitutionTypeInstitution> builder)
    {
        builder.HasKey(e => new { EstablishmentTypeId = e.InstitutionTypeId, EstablishmentId = e.InstitutionId });
        builder.HasIndex(e => new { EstablishmentTypeId = e.InstitutionTypeId, EstablishmentId = e.InstitutionId })
            .IsUnique();

        builder.HasOne(e => e.InstitutionType)
            .WithMany(e => e.InstitutionTypes)
            .HasForeignKey(e => e.InstitutionTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Institution)
            .WithMany(e => e.InstitutionTypes)
            .HasForeignKey(e => e.InstitutionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}