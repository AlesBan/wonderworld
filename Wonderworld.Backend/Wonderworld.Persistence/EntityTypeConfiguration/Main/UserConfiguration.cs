using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.Entities.Interface;
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

        builder.HasOne(t => t.InterfaceLanguage)
            .WithMany(il => il.Users)
            .HasForeignKey(t => t.InterfaceLanguageId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(t => t.CityLocation)
            .WithMany(cl => cl.Teachers)
            .HasForeignKey(t => t.CityLocationId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(t => t.Establishment)
            .WithMany(e => e.Teachers)
            .HasForeignKey(t => t.EstablishmentId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Property(t => t.Aims)
            .HasMaxLength(255);
        builder.Property(t => t.Description)
            .HasMaxLength(300);

        builder.HasOne(t => t.Appointment)
            .WithMany(a => a.Teachers)
            .HasForeignKey(t => t.AppointmentId)
            .OnDelete(DeleteBehavior.SetNull);

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