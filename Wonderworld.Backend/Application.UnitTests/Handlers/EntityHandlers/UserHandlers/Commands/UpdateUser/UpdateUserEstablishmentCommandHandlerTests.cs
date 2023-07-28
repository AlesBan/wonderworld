using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserEstablishment;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUser;

public class UpdateUserEstablishmentCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task UpdateUserEstablishmentCommandHandler_Handle_ShouldUpdateUserEstablishment()
    {
        // Arrange
        var user = await Context.Users.SingleOrDefaultAsync(u =>
            u.UserId == SharedLessonDbContextFactory.UserAId);
        var newEstablishment = await Context.Establishments.SingleOrDefaultAsync(e =>
            e.EstablishmentId == SharedLessonDbContextFactory.EstablishmentBId);

        var handler = new UpdateUserEstablishmentCommandHandler(Context);

        // Act
        await handler.Handle(new UpdateUserEstablishmentCommand()
        {
            Establishment = newEstablishment!,
            User = user!
        }, CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Users.SingleOrDefaultAsync(e =>
            e.EstablishmentId == newEstablishment!.EstablishmentId &&
            e.UserId == user!.UserId));
    }
}