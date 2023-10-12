using Application.UnitTests.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
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
        var mediatorMock = new Mock<IMediator>();

        var user = await Context.Users
            .SingleOrDefaultAsync(x =>
                x.UserId == SharedLessonDbContextFactory.UserAId);
        var newDisciplines = new List<Discipline>()
        {
            Context.Disciplines.SingleAsync(x =>
                x.Title == "History").Result
        };
        var handler = new UpdateUserDisciplinesCommandHandler(Context, mediatorMock.Object);

        // Act
        await handler.Handle(new UpdateUserDisciplinesCommand()
        {
            UserId = user!.UserId,
            NewDisciplineIds = newDisciplines.Select(d =>
                    d.DisciplineId)
                .ToList()
        }, CancellationToken.None);

        // Assert
        Assert.Equal(1, Context.UserDisciplines.Count(ud => ud.UserId == user!.UserId));
        Assert.NotEmpty(Context.UserDisciplines
            .Where(ud => ud.UserId == user!.UserId &&
                         ud.Discipline.Title == "History"));
    }
}