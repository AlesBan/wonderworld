using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Persistence.EntityConnectionsConfiguration;

public class ClassLanguageConfiguration : IEntityTypeConfiguration<ClassLanguage>
{
    public void Configure(EntityTypeBuilder<ClassLanguage> builder)
    {
        builder.HasKey(cl => new { cl.LanguageId, cl.ClassId });
        builder.HasIndex(cl => new { cl.LanguageId, cl.ClassId }).IsUnique();

        builder.HasOne(cl => cl.Class)
            .WithMany(c => c.ClassLanguages)
            .HasForeignKey(cl => cl.ClassId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(cl => cl.Language)
            .WithMany(c => c.ClassLanguages)
            .HasForeignKey(cl => cl.LanguageId)            
            .OnDelete(DeleteBehavior.Cascade);
    }
}