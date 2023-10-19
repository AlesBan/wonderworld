using Application.UnitTests.Common;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Common.Exceptions.Database;
using Wonderworld.Application.Common.Exceptions.User;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserById;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.UserHandlers.Queries;

public class GetUserCommandHandlerTests : TestCommonBase
{
    [Fact]
    public void Handle_ShouldReturnUser()
    {
        // Arrange
        var userId = SharedLessonDbContextFactory.UserAId;
        var handler = new GetUserByIdQueryHandler(Context);

        // Act
        var result = handler.Handle(new GetUserByIdQuery(userId), CancellationToken.None);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Handle_ShouldThrowNotFoundException()
    {
        // Arrange
        var userId = Guid.NewGuid();

        var handler = new GetUserByIdQueryHandler(Context);

        // Act
        // Assert
        await Assert.ThrowsAsync<UserNotFoundException>(() =>
            handler.Handle(new GetUserByIdQuery(userId), CancellationToken.None));
    }
}