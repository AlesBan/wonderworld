using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.Entities.Job;

namespace Wonderworld.Persistence.EntityConfiguration.Job;

public class EstablishmentConfiguration : IEntityTypeConfiguration<Establishment>
{
    public void Configure(EntityTypeBuilder<Establishment> builder)
    {
        builder.HasKey(e => e.EstablishmentId);
        builder.HasIndex(e => e.EstablishmentId)
            .IsUnique();
        builder.Property(e => e.EstablishmentId)
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