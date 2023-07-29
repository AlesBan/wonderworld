using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Handlers.EntityHandlers.FeedbackHandlers.Commands.CreateFeedback;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.FeedbackHandlers.Commands;

public class CreateFeedbackCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task CreateFeedbackCommandHandler_Handle_ShouldCreateFeedback()
    {
        // Arrange
        var invitation = await Context.Invitations
            .FirstOrDefaultAsync(i =>
                i.InvitationId == SharedLessonDbContextFactory.InvitationAId);
        const bool wasTheJointLesson = true;
        string? reasonForNotConducting = null;
        const string feedbackText = "Feedback text";
        const int rating = 5;

        var handler = new CreateFeedbackCommandHandler(Context);

        // Act
        var result = await handler.Handle(new CreateFeedbackCommand
        {
            Invitation = invitation!,
            WasTheJointLesson = wasTheJointLesson,
            ReasonForNotConducting = reasonForNotConducting,
            FeedbackText = feedbackText,
            Rating = rating,
        }, CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Feedbacks.FirstOrDefaultAsync(f =>
            f.FeedbackId == result));
    }
}