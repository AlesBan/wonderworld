using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplineHandlers.Commands.CreateUserDisciplines;
using Xunit;

namespace Application.UnitTests.Handlers.EntityConnectionHandlers.UserDisciplineHandlers.Commands;

public class CreateUserDisciplineCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task CreateUserDisciplinesCommandHandler_Handle_ShouldCreateUserDiscipline()
    {
        // Arrange
        var user = await Context.Users
            .SingleOrDefaultAsync(x => 
            x.UserId == SharedLessonDbContextFactory.UserRegisteredId);
        var discipline = Extensions.PickRandom(Context.Disciplines.ToList(), 1).ToList().First();

        var handler = new CreateUserDisciplineCommandHandler(Context);

        // Act
        await handler.Handle(new CreateUserDisciplineCommand()
        {
            User = user!,
            Discipline = discipline
        }, CancellationToken.None);

        // Assert
        Assert.NotEmpty(Context.UserDisciplines
            .Where(ud => ud.UserId == user!.UserId &&
                         ud.Discipline.Title == discipline.Title));
    }
}