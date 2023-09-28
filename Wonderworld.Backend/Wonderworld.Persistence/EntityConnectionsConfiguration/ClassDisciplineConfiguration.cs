using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Persistence.EntityConnectionsConfiguration;

public class ClassDisciplineConfiguration : IEntityTypeConfiguration<ClassDiscipline>
{
    public void Configure(EntityTypeBuilder<ClassDiscipline> builder)
    {
        builder.HasKey(cd => new { cd.ClassId, cd.DisciplineId });
        builder.HasIndex(cd => new { cd.ClassId, cd.DisciplineId }).IsUnique();

        builder.HasOne(cd => cd.Class)
            .WithMany(c => c.ClassDisciplines)
            .HasForeignKey(cd => cd.ClassId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(cd => cd.Discipline)
            .WithMany(d => d.ClassDisciplines)
            .HasForeignKey(cd => cd.DisciplineId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}