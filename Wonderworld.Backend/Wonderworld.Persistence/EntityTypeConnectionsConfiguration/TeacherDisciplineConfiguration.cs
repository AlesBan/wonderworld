using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.ConnectionEntities;

namespace Wonderworld.Persistence.EntityTypeConnectionsConfiguration;

public class TeacherDisciplineConfiguration : IEntityTypeConfiguration<TeacherDiscipline>
{
    public void Configure(EntityTypeBuilder<TeacherDiscipline> builder)
    {
        builder.HasKey(td => new { td.DisciplineId, td.TeacherId });

        builder.HasOne(td => td.Teacher)
            .WithMany(t => t.TeacherDisciplines)
            .HasForeignKey(td => td.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(td => td.Discipline)
            .WithMany(d => d.TeacherDisciplines)
            .HasForeignKey(td => td.DisciplineId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}