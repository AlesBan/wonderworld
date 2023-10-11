using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserPassword;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUser;

public class UpdateUserPasswordCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task UpdateUserPasswordCommandHandler_Handle_ShouldUpdateUserPassword()
    {
        // Arrange
        var userId = SharedLessonDbContextFactory.UserAId;
        const string newPassword = "NewPassword";

        var handler = new UpdateUserPasswordCommandHandler(Context);

        // Act
        await handler.Handle(new UpdateUserPasswordCommand()
        {
            UserId = userId,
            Password = newPassword
        }, CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Users.SingleOrDefaultAsync(u =>
            u.UserId == userId &&
            u.Password == newPassword));
    }
}