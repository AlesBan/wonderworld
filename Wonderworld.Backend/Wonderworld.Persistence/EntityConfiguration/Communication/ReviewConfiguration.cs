using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderworld.Domain.Entities.Communication;

namespace Wonderworld.Persistence.EntityTypeConfiguration.Communication;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(f => f.ReviewId);
        builder.HasIndex(f => f.ReviewId)
            .IsUnique();
        builder.Property(c => c.ReviewId)
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.HasOne(f => f.Invitation)
            .WithMany(i => i.Reviews)
            .HasForeignKey(f => f.InvitationId)
            .IsRequired();

        builder.HasOne(f => f.UserSender)
            .WithMany(u => u.SentReviews)
            .HasForeignKey(f => f.UserSenderId)
            .IsRequired();
        
        builder.HasOne(f => f.UserRecipient)
            .WithMany(u => u.ReceivedReviews)
            .HasForeignKey(f => f.UserRecipientId)
            .IsRequired();
        
        builder.Property(f => f.WasTheJointLesson)
            .IsRequired();

        builder.Property(f => f.ReasonForNotConducting)
            .HasMaxLength(255);

        builder.Property(f => f.ReviewText)
            .HasMaxLength(255);
        builder.Property(f => f.Rating)
            .HasColumnType("SMALLINT");
    }
}