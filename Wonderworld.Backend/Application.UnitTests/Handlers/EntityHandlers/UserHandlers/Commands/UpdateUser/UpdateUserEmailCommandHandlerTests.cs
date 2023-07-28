using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserEmail;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUser;

public class UpdateUserEmailCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task UpdateUserEmailCommandHandler_Handle_ShouldUpdateUserEmail()
    {
        // Arrange
        var user = await Context.Users.SingleOrDefaultAsync(u =>
            u.UserId == SharedLessonDbContextFactory.UserAId);
        const string newEmail = "NewEmail";

        var handler = new UpdateUserEmailCommandHandler(Context);

        // Act
        await handler.Handle(new UpdateUserEmailCommand()
        {
            User = user!,
            NewEmail = newEmail
        }, CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Users.SingleOrDefaultAsync(u =>
            u.UserId == user!.UserId &&
            u.Email == newEmail));
    }
}