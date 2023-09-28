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

        builder.HasOne(c => c.Grade)
            .WithMany(g => g.Classes)
            .HasForeignKey(c => c.GradeId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(c => c.Title)
            .HasMaxLength(40)
            .IsRequired();

        builder.Property(c => c.Age)
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(c => c.PhotoUrl)
            .HasMaxLength(200);

        builder.Property(c => c.CreatedAt)
            .HasDefaultValueSql("now()")
            .ValueGeneratedOnAdd();

        builder.Property(c => c.UserId)
            .IsRequired();

        builder.HasOne(c => c.User)
            .WithMany(c => c.Classes)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}