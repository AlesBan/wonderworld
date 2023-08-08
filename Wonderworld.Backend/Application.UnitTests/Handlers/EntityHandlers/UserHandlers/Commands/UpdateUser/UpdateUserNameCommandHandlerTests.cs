using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserName;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUser;

public class UpdateUserNameCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task UpdateUserNameCommandHandler_Handle_ShouldUpdateUserName()
    {
        // Arrange
        var user = await Context.Users
            .SingleOrDefaultAsync(x =>
                x.UserId == SharedLessonDbContextFactory.UserAId);
        const string newUserFirstName = "newUserName";
        const string newUserLastName = "newLastName";
        var handler = new UpdateUserNameCommandHandler(Context);

        // Act
        await handler.Handle(new UpdateUserNameCommand()
        {
            User = user!,
            FirstName = newUserFirstName,
            LastName = newUserLastName
        }, CancellationToken.None);

        // Assert
        Assert.NotNull(Context.Users.SingleOrDefaultAsync(u =>
            u.UserId == user!.UserId &&
            u.FirstName == newUserFirstName &&
            u.LastName == newUserLastName));
    }
}