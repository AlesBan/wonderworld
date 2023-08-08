using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.Entities;
using Wonderworld.Domain.Entities.Job;

namespace Wonderworld.Persistence.EntityTypeConfiguration;

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

        builder.Property(e => e.Type)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(e => e.Title)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasOne(e => e.City)
            .WithMany(c => c.Establishments)
            .HasForeignKey(e => e.CityId);
    }
}