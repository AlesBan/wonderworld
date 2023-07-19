using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Persistence.EntityTypeConfiguration.Main;

public class ClassConfiguration : IEntityTypeConfiguration<Class>
{
    public void Configure(EntityTypeBuilder<Class> builder)
    {
        builder.HasKey(c => c.ClassId);
        builder.HasIndex(c => c.ClassId)
            .IsUnique();
        builder.Property(c => c.ClassId)
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(c => c.ClassNumber)
            .HasColumnType("SMALLINT")
            .IsRequired();
        builder.Property(c => c.ClassAge)
            .HasColumnType("SMALLINT")
            .IsRequired();

        builder.Property(c=>c.CreatedAt)
            .HasDefaultValueSql("now()")
            .ValueGeneratedOnAdd();
        
        builder.Property(c => c.TeacherId)
            .IsRequired();

        builder.HasOne(c => c.Teacher)
            .WithMany(c => c.Classes)
            .HasForeignKey(c => c.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}