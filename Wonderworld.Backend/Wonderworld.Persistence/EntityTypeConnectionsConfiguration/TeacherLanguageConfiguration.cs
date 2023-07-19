using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.ConnectionEntities;

namespace Wonderworld.Persistence.EntityTypeConnectionsConfiguration;

public class TeacherLanguageConfiguration : IEntityTypeConfiguration<TeacherLanguage>
{
    public void Configure(EntityTypeBuilder<TeacherLanguage> builder)
    {
        builder.HasKey(tl => new { tl.TeacherId, tl.LanguageId });

        builder.HasOne(tl => tl.Teacher)
            .WithMany(t => t.TeacherLanguages)
            .HasForeignKey(tl => tl.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(tl => tl.Language)
            .WithMany(t => t.TeacherLanguages)
            .HasForeignKey(tl => tl.LanguageId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}