using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserPosition;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUser;

public class UpdateUserPositionCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task UpdateUserPositionCommandHandler_Handle_ShouldUpdateUserPosition()
    {
        // Arrange
        var user = await Context.Users
            .SingleOrDefaultAsync(x =>
                x.UserId == SharedLessonDbContextFactory.UserAId);
        const bool newIsATeacher = false;
        const bool newIsAnExpert = true;

        var handler = new UpdateUserPositionCommandHandler(Context);

        // Act
        await handler.Handle(new UpdateUserPositionCommand()
        {
            User = user!,
            IsATeacher = newIsATeacher,
            IsAnExpert = newIsAnExpert,
        }, CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Users.SingleOrDefaultAsync(u =>
            u.UserId == user!.UserId &&
            u.IsATeacher == newIsATeacher &&
            u.IsAnExpert == newIsAnExpert));
    }
}