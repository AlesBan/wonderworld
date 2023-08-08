using Application.UnitTests.Common;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserGradeHandlers.Commands.DeleteUserGrade;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserLanguagesHandlers.Commands.DeleteUserLanguages;
using Xunit;

namespace Application.UnitTests.Handlers.EntityConnectionHandlers.UserGradeHandlers.Commands;

public class DeleteUserGradeCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task DeleteUserGradeCommandHandler_Handle_ShouldDeleteUserGrade()
    {
        // Arrange
        var userId = SharedLessonDbContextFactory.UserAId;
        var user = Context.Users.SingleOrDefault(x => 
            x.UserId == userId);
        var gradeForDelete = Context.Grades
            .SingleOrDefault(x => x.GradeNumber == 10)!;

        var handler = new DeleteUserGradeCommandHandler(Context);

        // Act
        await handler.Handle(new DeleteUserGradeCommand
        {
            User = user!,
            Grade = gradeForDelete
        }, CancellationToken.None);

        // Assert
        Assert.Empty(Context.UserGrades
            .Where(ug => ug.UserId == userId &&
                         ug.Grade.GradeId == gradeForDelete.GradeId));
    }

    [Fact]
    public async Task DeleteUserGradeCommandHandler_Handle_FailOnWrongId()
    {
        // Arrange
        var user = Context.Users.SingleOrDefault(x =>
            x.UserId == SharedLessonDbContextFactory.UserRegisteredId);
        var gradeForDelete = Context.Grades.SingleOrDefault(x => x.GradeNumber == 4)!;

        var handler = new DeleteUserGradeCommandHandler(Context);

        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new DeleteUserGradeCommand
            {
                User = user!,
                Grade = gradeForDelete
            }, CancellationToken.None));
    }
}