using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Persistence.EntityConnectionsConfiguration;

public class UserRoleConfiguration: IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(ur => new { ur.UserId, ur.RoleId });
        builder.HasIndex(ur => new { ur.UserId, ur.RoleId }).IsUnique();
        
        builder.HasOne(ur=>ur.User)
            .WithMany(u=>u.UserRoles)
            .HasForeignKey(ur=>ur.UserId);
        
        builder.HasOne(ur=>ur.Role)
            .WithMany(r=>r.UserRoles)
            .HasForeignKey(ur=>ur.RoleId);
    }
}