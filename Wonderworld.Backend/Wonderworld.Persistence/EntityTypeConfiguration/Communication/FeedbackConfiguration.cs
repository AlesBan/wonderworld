using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.Entities.Communication;

namespace Wonderworld.Persistence.EntityTypeConfiguration.Communication;

public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        builder.HasKey(f => f.FeedbackId);
        builder.HasIndex(f => f.FeedbackId)
            .IsUnique();
        builder.Property(c => c.FeedbackId)
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.HasOne(f => f.TeacherFeedbackSender)
            .WithMany(t => t.SentFeedbacks)
            .HasForeignKey(f => f.TeacherFeedbackSenderId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        
        builder.HasOne(f => f.TeacherFeedbackRecipient)
            .WithMany(t => t.RecievedFeedbacks)
            .HasForeignKey(f => f.TeacherFeedbackRecipientId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.Property(f => f.WasTheJointLesson)
            .IsRequired();

        builder.Property(f => f.ReasonForNotConducting)
            .HasMaxLength(255);
        
        builder.Property(f => f.FeedbackText)
            .HasMaxLength(255);
        builder.Property(f => f.Rating)
            .HasColumnType("SMALLINT");
    }
}