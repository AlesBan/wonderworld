using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.Entities.Job;

namespace Wonderworld.Persistence.EntityConfiguration.Job;

public class InstitutionTypeConfiguration : IEntityTypeConfiguration<InstitutionType>
{
    public void Configure(EntityTypeBuilder<InstitutionType> builder)
    {
        builder.HasKey(e => e.InstitutionTypeId);
        builder.HasIndex(e => e.InstitutionTypeId)
            .IsUnique();
        
        builder.Property(e => e.InstitutionTypeId)
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Title)
            .HasMaxLength(20);
    }
}