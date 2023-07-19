using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.Entities.Communication;

namespace Wonderworld.Persistence.EntityTypeConfiguration.Communication;

public class InvitationConfiguration : IEntityTypeConfiguration<Invitation>
{
    public void Configure(EntityTypeBuilder<Invitation> builder)
    {
        builder.HasKey(t => t.TeacherInvitationId);
        builder.HasIndex(t => t.TeacherInvitationId)
            .IsUnique();
        builder.Property(t => t.TeacherInvitationId)
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.HasOne(t => t.TeacherInvitationSender)
            .WithMany(ti => ti.SentInvitations)
            .HasForeignKey(ti => ti.TeacherInvitationSenderId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .IsRequired();
        builder.HasOne(t => t.TeacherInvitationRecipient)
            .WithMany(tr => tr.RecievedInvitations)
            .HasForeignKey(t => t.TeacherInvitationRecipientId)
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