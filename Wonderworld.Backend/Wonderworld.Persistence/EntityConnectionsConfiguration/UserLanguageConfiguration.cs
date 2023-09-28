using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Persistence.EntityConnectionsConfiguration;

public class UserLanguageConfiguration : IEntityTypeConfiguration<UserLanguage>
{
    public void Configure(EntityTypeBuilder<UserLanguage> builder)
    {
        builder.HasKey(tl => new { TeacherId = tl.UserId, tl.LanguageId });
        builder.HasIndex(tl => new { TeacherId = tl.UserId, tl.LanguageId }).IsUnique();

        builder.HasOne(tl => tl.User)
            .WithMany(t => t.UserLanguages)
            .HasForeignKey(tl => tl.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(tl => tl.Language)
            .WithMany(t => t.TeacherLanguages)
            .HasForeignKey(tl => tl.LanguageId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}