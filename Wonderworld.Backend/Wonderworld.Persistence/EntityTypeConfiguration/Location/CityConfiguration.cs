using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Persistence.EntityTypeConfiguration.Location;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(c => c.CityId);
        builder.HasIndex(c => c.CityId)
            .IsUnique();
        builder.Property(c => c.CityId)
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Title)
            .HasMaxLength(30)
            .IsRequired();

        builder.HasOne(c => c.Country)
            .WithMany(cn => cn.Cities)
            .HasForeignKey(c => c.CountryId);
    }
}