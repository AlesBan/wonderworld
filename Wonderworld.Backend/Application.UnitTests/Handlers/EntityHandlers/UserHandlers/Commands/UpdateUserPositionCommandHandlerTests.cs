using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Handlers.UserHandlers.Commands.UpdateUserPosition;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.UserHandlers.Commands;

public class UpdateUserPositionCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task UpdateUserPositionCommandHandler_Handle_ShouldUpdateUserPosition()
    {
        // Arrange
        var userId = SharedLessonDbContextFactory.UserAId;
        const bool newIsATeacher = false;
        const bool newIsAnExpert = true;
        
        var handler = new UpdateUserPositionCommandHandler(Context);
        
        // Act
        await handler.Handle(new UpdateUserPositionCommand()
        {
            UserId = userId,
            IsATeacher = newIsATeacher,
            IsAnExpert = newIsAnExpert,
        }, CancellationToken.None);
        
        // Assert
        Assert.NotNull(await Context.Users.SingleOrDefaultAsync(u =>
            u.UserId == userId &&
            u.IsATeacher == newIsATeacher &&
            u.IsAnExpert == newIsAnExpert));
    }
    
    [Fact]
    public async Task UpdateUserPositionCommand_Handle_FailOnWrongId()
    {
        // Arrange
        var handler = new UpdateUserPositionCommandHandler(Context);

        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new UpdateUserPositionCommand { UserId = Guid.NewGuid() },
                CancellationToken.None));
    }
}