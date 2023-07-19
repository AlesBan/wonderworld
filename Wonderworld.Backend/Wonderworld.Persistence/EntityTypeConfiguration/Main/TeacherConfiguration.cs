using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Persistence.EntityTypeConfiguration.Main;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasKey(t => t.TeacherId);
        builder.HasIndex(t => t.TeacherId).IsUnique();
        builder.Property(t => t.TeacherId)
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();
        
        builder.Property(t => t.FirstName)
            .HasMaxLength(40)
            .IsRequired();
        builder.Property(t => t.LastName)
            .HasMaxLength(40)
            .IsRequired();

        builder.Property(t => t.Email)
            .HasMaxLength(60)
            .IsRequired();
        builder.Property(t => t.Password)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(t => t.Appointment)
            .WithMany(a => a.Teachers)
            .HasForeignKey(t => t.AppointmentId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(t => t.Establishment)
            .WithMany(e => e.Teachers)
            .HasForeignKey(t => t.EstablishmentId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Property(t => t.Aims)
            .HasMaxLength(255);
        builder.Property(t => t.Description)
            .HasMaxLength(300);

        builder.HasOne(t => t.InterfaceLanguage)
            .WithMany(il => il.Teachers)
            .HasForeignKey(t => t.InterfaceLanguageId)
            .OnDelete(DeleteBehavior.SetNull)
            .IsRequired();

        builder.Property(t => t.PhotoUrl)
            .HasMaxLength(255);
        builder.Property(t => t.BannerPhotoUrl)
            .HasMaxLength(255);

        builder.Property(t => t.IsVerified)
            .IsRequired();
            
        builder.Property(t => t.CreatedAt)
            .HasDefaultValueSql("now()")
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Property(t => t.LastOnlineAt)
            .IsRequired();
    }
}