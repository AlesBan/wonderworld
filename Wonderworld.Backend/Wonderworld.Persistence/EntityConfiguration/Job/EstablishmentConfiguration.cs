using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.Entities.Job;

namespace Wonderworld.Persistence.EntityConfiguration.Job;

public class EstablishmentConfiguration : IEntityTypeConfiguration<Institution>
{
    public void Configure(EntityTypeBuilder<Institution> builder)
    {
        builder.HasKey(e => e.InstitutionId);
        builder.HasIndex(e => e.InstitutionId)
            .IsUnique();
        builder.Property(e => e.InstitutionId)
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Title)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(e => e.Address)
            .HasMaxLength(150)
            .IsRequired();
    }
}