using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserPhoto;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUser;

public class UpdateUserPhotoCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task UpdateUserPhotoCommandHandler_Handle_ShouldUpdateUserPhoto()
    {
        // Arrange
        var user = await Context.Users.SingleOrDefaultAsync(u =>
            u.UserId == SharedLessonDbContextFactory.UserAId);
        const string newPhotoUrl = "NewPhotoUrl";

        var handler = new UpdateUserPhotoCommandHandler(Context);

        // Act
        await handler.Handle(new UpdateUserPhotoCommand()
        {
            User = user!,
            NewPhotoUrl = newPhotoUrl
        }, CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Users.SingleOrDefaultAsync(u =>
            u.UserId == user!.UserId &&
            u.PhotoUrl == newPhotoUrl));
    }
}