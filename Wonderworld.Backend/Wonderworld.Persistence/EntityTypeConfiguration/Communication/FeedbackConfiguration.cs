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

        builder.HasOne(f => f.Invitation)
            .WithOne(i => i.Feedback)
            .HasForeignKey<Feedback>(f => f.InvitationId)
            .IsRequired();

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