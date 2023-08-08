using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Persistence.EntityTypeConfiguration.Main;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(t => t.UserId);
        builder.HasIndex(t => t.UserId)
            .IsUnique();
        builder.Property(t => t.UserId)
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.FirstName)
            .HasMaxLength(40);
        builder.Property(t => t.LastName)
            .HasMaxLength(40);

        builder.HasOne(t => t.CityLocation)
            .WithMany(cl => cl.Users)
            .HasForeignKey(t => t.CityLocationId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(t => t.Establishment)
            .WithMany(e => e.Users)
            .HasForeignKey(t => t.EstablishmentId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Property(u => u.Rating)
            .HasColumnType("numeric(3,2)")
            .HasDefaultValue(0.0)
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Description)
            .HasMaxLength(300);

        builder.Property(t => t.PhotoUrl)
            .HasMaxLength(255);
        builder.Property(t => t.BannerPhotoUrl)
            .HasMaxLength(255);

        builder.Property(t => t.RegisteredAt)
            .HasDefaultValueSql("now()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(t => t.LastOnlineAt)
            .HasDefaultValueSql("now()")
            .IsRequired();
    }
}