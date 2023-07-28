using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserDescription;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUser;

public class UpdateUserDescriptionCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task UpdateUserDescriptionCommandHandler_Handle_ShouldUpdateUserDescription()
    {
        // Arrange
        var user = await Context.Users.SingleOrDefaultAsync(u =>
            u.UserId == SharedLessonDbContextFactory.UserAId);
        const string newDescription = "NewDescription";

        var handler = new UpdateUserDescriptionCommandHandler(Context);

        // Act
        await handler.Handle(new UpdateUserDescriptionCommand()
        {
            User = user!,
            Description = newDescription
        }, CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Users.SingleOrDefaultAsync(u =>
            u.UserId == user!.UserId &&
            u.Description == newDescription));
    }
}