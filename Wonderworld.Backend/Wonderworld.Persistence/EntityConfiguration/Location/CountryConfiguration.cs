using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Persistence.EntityConfiguration.Location;

public class CountryConfiguration: IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(c => c.CountryId);
        builder.HasIndex(c => c.CountryId)
            .IsUnique();
        builder.Property(c => c.CountryId)
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();
    }
}