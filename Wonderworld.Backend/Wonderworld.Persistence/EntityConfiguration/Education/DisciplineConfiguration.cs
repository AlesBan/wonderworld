using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.Entities.Education;

namespace Wonderworld.Persistence.EntityTypeConfiguration.Education;

public class DisciplineConfiguration: IEntityTypeConfiguration<Discipline>
{
    public void Configure(EntityTypeBuilder<Discipline> builder)
    {
        builder.HasKey(d => d.DisciplineId);
        builder.HasIndex(d => d.DisciplineId)
            .IsUnique();
        builder.Property(d => d.DisciplineId)
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(d => d.Title)
            .HasMaxLength(30)
            .IsRequired();
    }
}