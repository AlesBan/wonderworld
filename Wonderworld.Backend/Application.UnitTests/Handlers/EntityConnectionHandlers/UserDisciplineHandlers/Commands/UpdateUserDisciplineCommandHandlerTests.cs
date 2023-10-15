using Application.UnitTests.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplineHandlers.Commands.UpdateUserDisciplines;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplinesHandlers.Commands.CreateUserDisciplines;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplinesHandlers.Commands.UpdateUserDisciplines;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.EntityConnections;
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

        var mockMediator = new Mock<IMediator>();
        var createUserDisciplineCommand = new CreateUserDisciplinesCommand()
        {
            UserId = user!.UserId,
            DisciplineIds = newDisciplines.Select(d =>
                    d.DisciplineId)
                .ToList()
        };
        var createUserDisciplineCommandHandler = new CreateUserDisciplinesCommandHandler(Context);
        var result =
            await createUserDisciplineCommandHandler.Handle(createUserDisciplineCommand, CancellationToken.None);


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
    
    [Fact]
    public async Task Handle_ValidCommand_UpdateUserDisciplinesAndCreateUserDisciplines()
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
        var newDisciplineIds = newDisciplines.Select(d => d.DisciplineId).ToList();

        var updateUserDisciplinesCommand = new UpdateUserDisciplinesCommand
        {
            UserId = user.UserId,
            NewDisciplineIds = newDisciplineIds
        };

        var handler = new UpdateUserDisciplinesCommandHandler(Context, mediatorMock.Object);

        // Act
        await handler.Handle(updateUserDisciplinesCommand, CancellationToken.None);

        // Assert
        mediatorMock.Verify(m => m.Send(It.Is<CreateUserDisciplinesCommand>(cmd =>
            cmd.UserId == user.UserId &&
            cmd.DisciplineIds.SequenceEqual(newDisciplineIds)
        ), CancellationToken.None), Times.Once);
        Assert.Equal(1, Context.UserDisciplines.Count(ud => ud.UserId == user!.UserId));
        Assert.NotEmpty(Context.UserDisciplines
            .Where(ud => ud.UserId == user!.UserId &&
                         ud.Discipline.Title == "History"));
    }
}