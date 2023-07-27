using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Handlers.UserHandlers.Commands.DeleteUser;
using Xunit;

namespace Application.UnitTests.Handlers.UserHandlers.Commands;

public class DeleteUserCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task DeleteUserCommandHandler_Handle_ShouldDeleteUser()
    {
        // Arrange
        var userForDeleteId = SharedLessonDbContextFactory.UserForDeleteId;

        var handler = new DeleteUserCommandHandler(Context);

        // Act
        await handler.Handle(new DeleteUserCommand()
        {
            UserId = userForDeleteId
        }, CancellationToken.None);

        // Assert
        Assert.Null(await Context.Users.SingleOrDefaultAsync(u =>
            u.UserId == userForDeleteId));
    }

    [Fact]
    public async Task DeleteUserCommandHandler_Handle_FailOnWrongId()
    {
        // Arrange
        var handler = new DeleteUserCommandHandler(Context);
        
        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new DeleteUserCommand { UserId = Guid.NewGuid() }, 
                CancellationToken.None));
    }
}