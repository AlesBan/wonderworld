using Application.UnitTests.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Commands.CreateClass;
using Wonderworld.Domain.Entities.Education;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.ClassHandlers.Commands;

public class CreateClassCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task CreateClassCommand_Handle_ShouldCreateClass()
    {
        // Arrange
        var user = await Context.Users.SingleOrDefaultAsync(u =>
            u.UserId == SharedLessonDbContextFactory.UserAId);
        const string title = "Title";
        const string photoUrl = "PhotoUrl";

        var grade = await Context.Grades.SingleOrDefaultAsync(g => g.GradeNumber == 6);
        var disciplines = new List<Discipline>
        {
            (await Context.Disciplines.SingleOrDefaultAsync(d => d.Title == "Chemistry"))!
        };
        var languages = new List<Language>
        {
            (await Context.Languages.SingleOrDefaultAsync(l => l.Title == "English"))!
        };

        var mediatorMock = new Mock<IMediator>();


        var handler = new CreateClassCommandHandler(Context, mediatorMock.Object);
        var createClassCommand = new CreateClassCommand()
        {
            UserId = user!.UserId,
            Title = title,
            GradeNumber = grade!.GradeNumber,
            Disciplines = disciplines,
            Languages = languages,
            PhotoUrl = photoUrl
        };

        // Act
        await handler.Handle(createClassCommand,
            CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Classes.SingleOrDefaultAsync(c =>
            c.Title == title &&
            c.UserId == user.UserId &
            c.Grade == grade &&
            c.ClassDisciplines.Count == disciplines.Count &&
            c.ClassLanguages.Count == languages.Count &&
            c.PhotoUrl == photoUrl));
    }
}