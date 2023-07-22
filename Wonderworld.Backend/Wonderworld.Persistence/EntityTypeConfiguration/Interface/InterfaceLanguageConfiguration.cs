using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.Entities.Interface;

namespace Wonderworld.Persistence.EntityTypeConfiguration.Interface;

public class InterfaceLanguageConfiguration : IEntityTypeConfiguration<InterfaceLanguage>
{
    public void Configure(EntityTypeBuilder<InterfaceLanguage> builder)
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