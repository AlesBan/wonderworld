using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.Entities.Job;

namespace Wonderworld.Persistence.EntityTypeConfiguration.Job;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(t => t.AppointmentId);
        builder.HasIndex(t => t.AppointmentId)
            .IsUnique();
        builder.Property(t => t.AppointmentId)
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Title)
            .HasMaxLength(30)
            .IsRequired();
    }
}