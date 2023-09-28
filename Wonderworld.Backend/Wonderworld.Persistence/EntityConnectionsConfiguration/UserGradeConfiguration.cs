using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Persistence.EntityConnectionsConfiguration;

public class UserGradeConfiguration : IEntityTypeConfiguration<UserGrade>
{
    public void Configure(EntityTypeBuilder<UserGrade> builder)
    {
        builder.HasKey(l => new { l.UserId, l.GradeId });
        builder.HasIndex(l => new { l.UserId, l.GradeId }).IsUnique();

        builder.HasOne(ug => ug.User)
            .WithMany(t => t.UserGrades)
            .HasForeignKey(ug => ug.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(ug => ug.Grade)
            .WithMany(d => d.UserGrades)
            .HasForeignKey(ug => ug.GradeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}