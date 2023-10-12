using Application.UnitTests.Common;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserGradeHandlers.Commands.CreateUserGrade;
using Xunit;

namespace Application.UnitTests.Handlers.EntityConnectionHandlers.UserGradeHandlers.Commands;

public class CreateUserGradeCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task CreateUserGradeCommandHandler_Handle_ShouldCreateUserGrade()
    {
        // Arrange
        var user = Context.Users.SingleOrDefault(x =>
            x.UserId == SharedLessonDbContextFactory.UserRegisteredId);
        var grade = Extensions.PickRandom(Context.Grades.ToList(), 1)
            .ToList()
            .First();

        var handler = new CreateUserGradesCommandHandler(Context);

        // Act
        await handler.Handle(new CreateUserGradesCommand()
        {
            UserId = user!.UserId,
            GradeIds = new List<Guid> { grade!.GradeId }
        }, CancellationToken.None);

        // Assert
        Assert.NotEmpty(Context.UserGrades
            .Where(ug => ug.UserId == user!.UserId &&
                         ug.Grade == grade));
    }
}