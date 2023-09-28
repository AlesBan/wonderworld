using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Persistence.EntityConfiguration.Main;

public class RoleConfiguration: IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(t => t.RoleId);
        builder.HasIndex(t => t.RoleId).IsUnique();
        builder.Property(t => t.RoleId)
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();
        
        builder.Property(t => t.Title)
            .HasMaxLength(30)
            .IsRequired();
    }
}