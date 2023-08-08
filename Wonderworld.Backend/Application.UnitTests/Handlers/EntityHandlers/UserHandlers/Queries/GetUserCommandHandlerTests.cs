using Application.UnitTests.Common;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUser;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.UserHandlers.Queries;

public class GetUserCommandHandlerTests : TestCommonBase
{
    [Fact]
    public void Handle_ShouldReturnUser()
    {
        // Arrange
        var userId = SharedLessonDbContextFactory.UserAId;
        var handler = new GetUserCommandHandler(Context);

        // Act
        var result = handler.Handle(new GetUserCommand()
        {
            UserId = userId
        }, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Handle_ShouldThrowNotFoundException()
    {
        // Arrange
        var userId = Guid.NewGuid();

        var handler = new GetUserCommandHandler(Context);

        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(() =>
            handler.Handle(new GetUserCommand()
            {
                UserId = userId
            }, CancellationToken.None));
    }
}