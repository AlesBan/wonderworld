using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.Entities.Education;

namespace Wonderworld.Persistence.EntityTypeConfiguration.Education;

public class LanguageConfiguration: IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.HasKey(l => l.LanguageId);
        builder.HasIndex(l => l.LanguageId)
            .IsUnique();
        builder.Property(l => l.LanguageId)
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();
        
        builder.Property(l => l.Title)
            .HasMaxLength(30)
            .IsRequired();
    }
}