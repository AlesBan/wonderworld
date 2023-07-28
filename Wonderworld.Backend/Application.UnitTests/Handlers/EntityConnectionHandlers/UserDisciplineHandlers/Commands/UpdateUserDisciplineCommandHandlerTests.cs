using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplineHandlers.Commands.UpdateUserDisciplines;
using Wonderworld.Domain.Entities.Education;
using Xunit;

namespace Application.UnitTests.Handlers.EntityConnectionHandlers.UserDisciplineHandlers.Commands;

public class UpdateUserDisciplineCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task UpdateUserDisciplineCommandHandler_Handle_ShouldUpdateUserDiscipline()
    {
        // Arrange
        var user = await Context.Users
            .SingleOrDefaultAsync(x =>
                x.UserId == SharedLessonDbContextFactory.UserAId);
        var newDisciplines = new List<Discipline>()
        {
            Context.Disciplines.SingleAsync(x =>
                x.Title == "History").Result
        };
        var handler = new UpdateUserDisciplinesCommandHandler(Context);

        // Act
        await handler.Handle(new UpdateUserDisciplinesCommand()
        {
            User = user!,
            NewDisciplines = newDisciplines
        }, CancellationToken.None);
        
        // Assert
        Assert.Equal(1, Context.UserDisciplines.Count(ud => ud.UserId == user!.UserId));
        Assert.NotEmpty(Context.UserDisciplines
            .Where(ud => ud.UserId == user!.UserId &&
                         ud.Discipline.Title == "History"));
        
    }
}

