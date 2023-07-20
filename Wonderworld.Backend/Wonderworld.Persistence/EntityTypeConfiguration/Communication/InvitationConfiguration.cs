using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.Entities.Communication;

namespace Wonderworld.Persistence.EntityTypeConfiguration.Communication;

public class InvitationConfiguration : IEntityTypeConfiguration<Invitation>
{
    public void Configure(EntityTypeBuilder<Invitation> builder)
    {
        builder.HasKey(t => t.InvitationId);
        builder.HasIndex(t => t.InvitationId)
            .IsUnique();
        builder.Property(t => t.InvitationId)
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.HasOne(t => t.UserInvitationSender)
            .WithMany(ti => ti.SentInvitations)
            .HasForeignKey(ti => ti.UserInvitationSenderId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .IsRequired();
        
        builder.HasOne(t => t.UserInvitationRecipient)
            .WithMany(tr => tr.RecievedInvitations)
            .HasForeignKey(t => t.UserInvitationRecipientId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .IsRequired();

        builder.Property(t => t.CreatedAt)
            .HasDefaultValueSql("now()")
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.Property(t => t.DateOfInvitation)
            .IsRequired();

        builder.Property(t => t.InvitationText)
            .HasMaxLength(255);
        
        builder.Property(t => t.Status)
            .HasDefaultValue("Pending")
            .IsRequired();
    }
}