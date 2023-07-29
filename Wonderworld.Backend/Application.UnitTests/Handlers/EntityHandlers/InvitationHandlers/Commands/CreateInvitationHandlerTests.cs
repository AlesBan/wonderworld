using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Handlers.EntityHandlers.InvitationHandlers.Commands.CreateInvitation;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.InvitationHandlers.Commands;

public class CreateInvitationHandlerTests : TestCommonBase
{
    [Fact]
    public async Task CreateInvitationCommandHandler_Handle_ShouldCreateInvitation()
    {
        // ArrangeFindAsync
        var userSender = await Context.Users.FirstOrDefaultAsync(u =>
            u.UserId == SharedLessonDbContextFactory.UserAId);
        var userRecipient = await Context.Users.FirstOrDefaultAsync(u =>
            u.UserId == SharedLessonDbContextFactory.UserBId);
        var handler = new CreateInvitationCommandHandler(Context);

        // Act
    }
}