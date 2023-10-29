using System.Globalization;
using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Handlers.EntityHandlers.InvitationHandlers.Commands.CreateInvitation;
using Wonderworld.Domain.Enums;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.InvitationHandlers.Commands;

public class CreateInvitationCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task CreateInvitationCommandHandler_Handle_ShouldCreateInvitation()
    {
        // ArrangeFindAsync
        var classSenderId = SharedLessonDbContextFactory.ClassAId;
        var classReceiverId = SharedLessonDbContextFactory.ClassBId;

        var userSenderId = SharedLessonDbContextFactory.UserAId;
        var userReceiverId = SharedLessonDbContextFactory.UserBId;
        var invitationDate = DateTime.UtcNow;
        const string invitationText = "InvitationText";
        
        var handler = new CreateInvitationCommandHandler(Context);

        // Act
        await handler.Handle(new CreateInvitationCommand
        {
            UserSenderId = userSenderId,
            UserReceiverId = userReceiverId,
            ClassSenderId = classSenderId,
            ClassReceiverId = classReceiverId,
            InvitationText = invitationText,
            DateOfInvitation = invitationDate,
            Status = InvitationStatus.Pending.ToString()
        }, CancellationToken.None);
        
        // Assert
        Assert.NotNull(await Context.Invitations.SingleOrDefaultAsync(i =>
            i.UserSenderId == userSenderId &&
            i.UserReceiverId == userReceiverId &&
            i.ClassSenderId == classSenderId &&
            i.ClassReceiverId == classReceiverId &&
            i.DateOfInvitation.ToString(CultureInfo.InvariantCulture) == invitationDate.ToString(CultureInfo.InvariantCulture) &&
            i.Status == InvitationStatus.Pending.ToString() &&
            i.InvitationText == invitationText));
    }
}