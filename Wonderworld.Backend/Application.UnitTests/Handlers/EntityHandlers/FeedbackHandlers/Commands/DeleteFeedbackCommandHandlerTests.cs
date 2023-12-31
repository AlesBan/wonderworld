using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Handlers.EntityHandlers.FeedbackHandlers.Commands.DeleteFeedback;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.FeedbackHandlers.Commands;

public class DeleteFeedbackCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task DeleteFeedbackCommandHandler_Handle_ShouldDeleteFeedback()
    {
        // Arrange
        var feedback = await Context.Reviews.FirstOrDefaultAsync(f=>
            f.ReviewId == SharedLessonDbContextFactory.FeedbackForDeleteId);
        
        var handler = new DeleteFeedbackCommandHandler(Context);
        
        // Act
        await handler.Handle(new DeleteFeedbackCommand
        {
            Feedback = feedback!,
        }, CancellationToken.None);
        
        // Assert
        Assert.Null(await Context.Reviews.SingleOrDefaultAsync(f =>
            f.ReviewId == SharedLessonDbContextFactory.FeedbackForDeleteId));
    }
}