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
        var userSender = await Context.Users.FirstOrDefaultAsync(u =>
            u.UserId == SharedLessonDbContextFactory.UserAId);
        var userRecipient = await Context.Users.FirstOrDefaultAsync(u =>
            u.UserId == SharedLessonDbContextFactory.UserBId);
        var classSender = await Context.Classes.FirstOrDefaultAsync(c =>
            c.ClassId == SharedLessonDbContextFactory.ClassAId);
        var classRecipient = await Context.Classes.FirstOrDefaultAsync(c =>
            c.ClassId == SharedLessonDbContextFactory.ClassBId);
        var invitationDate = DateTime.Now;
        const string invitationText = "InvitationText";
        
        var handler = new CreateInvitationCommandHandler(Context);

        // Act
        await handler.Handle(new CreateInvitationCommand
        {
            UserSenderId = userSender!.UserId,
            UserReceiverId = userRecipient!.UserId,
            ClassSenderId = classSender!.ClassId,
            ClassReceiverId = classRecipient!.ClassId,
            InvitationText = invitationText,
            DateOfInvitation = invitationDate,
            Status = InvitationStatus.Pending.ToString()
        }, CancellationToken.None);
        
        // Assert
        Assert.NotNull(await Context.Invitations.SingleOrDefaultAsync(i =>
            i.UserSender == userSender &&
            i.UserReceiver == userRecipient &&
            i.ClassSender == classSender &&
            i.ClassReceiver == classRecipient &&
            i.DateOfInvitation == invitationDate &&
            i.Status == InvitationStatus.Pending.ToString() &&
            i.InvitationText == invitationText));
    }
}