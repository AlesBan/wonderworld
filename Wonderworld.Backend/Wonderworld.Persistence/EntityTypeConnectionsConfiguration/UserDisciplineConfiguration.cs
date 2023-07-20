using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.ConnectionEntities;

namespace Wonderworld.Persistence.EntityTypeConnectionsConfiguration;

public class UserDisciplineConfiguration : IEntityTypeConfiguration<UserDiscipline>
{
    public void Configure(EntityTypeBuilder<UserDiscipline> builder)
    {
        builder.HasKey(td => new { td.DisciplineId, TeacherId = td.UserId });
        builder.HasIndex(td => new { TeacherId = td.UserId, td.DisciplineId }).IsUnique();

        builder.HasOne(td => td.User)
            .WithMany(t => t.TeacherDisciplines)
            .HasForeignKey(td => td.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(td => td.Discipline)
            .WithMany(d => d.TeacherDisciplines)
            .HasForeignKey(td => td.DisciplineId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}