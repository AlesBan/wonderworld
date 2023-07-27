using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Handlers.UserHandlers.Commands.UpdateUserDescription;
using Wonderworld.Application.Handlers.UserHandlers.Commands.UpdateUserPosition;
using Xunit;

namespace Application.UnitTests.Handlers.UserHandlers.Commands;

public class UpdateUserDescriptionCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task UpdateUserDescriptionCommandHandler_Handle_ShouldUpdateUserDescription()
    {
        // Arrange
        var userId = SharedLessonDbContextFactory.UserAId;
        const string newDescription = "NewDescription";

        var handler = new UpdateUserDescriptionCommandHandler(Context);

        // Act
        await handler.Handle(new UpdateUserDescriptionCommand()
        {
            UserId = userId,
            Description = newDescription
        }, CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Users.SingleOrDefaultAsync(u =>
            u.UserId == userId &&
            u.Description == newDescription));
    }

    [Fact]
    public async Task UpdateUserDescriptionCommand_Handle_FailOnWrongId()
    {
        // Arrange
        var handler = new UpdateUserDescriptionCommandHandler(Context);

        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new UpdateUserDescriptionCommand
                {
                    UserId = Guid.NewGuid()
                },
                CancellationToken.None));
    }
}