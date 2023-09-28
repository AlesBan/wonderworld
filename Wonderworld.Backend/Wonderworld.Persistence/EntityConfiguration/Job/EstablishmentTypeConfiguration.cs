using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.Entities.Job;

namespace Wonderworld.Persistence.EntityConfiguration.Job;

public class EstablishmentTypeConfiguration : IEntityTypeConfiguration<EstablishmentType>
{
    public void Configure(EntityTypeBuilder<EstablishmentType> builder)
    {
        builder.HasKey(e => e.EstablishmentTypeId);
        builder.HasIndex(e => e.EstablishmentTypeId)
            .IsUnique();
        
        builder.Property(e => e.EstablishmentTypeId)
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Title)
            .HasMaxLength(20);
    }
}