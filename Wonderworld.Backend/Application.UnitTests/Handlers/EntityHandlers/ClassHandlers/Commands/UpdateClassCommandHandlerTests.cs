using Application.UnitTests.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Commands.UpdateClass;
using Wonderworld.Domain.Entities.Education;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.ClassHandlers.Commands;

public class UpdateClassCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task UpdateClassCommand_Handle_ShouldUpdateClass()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var @class = await Context.Classes.FirstAsync(c =>
            c.ClassId == SharedLessonDbContextFactory.ClassForUpdateId);
        const string newTitle = "New Title";
        const string newPhotoUrl = "New PhotoUrl";
        var newDisciplines = new List<Discipline>
        {
            await Context.Disciplines.FirstAsync(d => d.Title == "Mathematics"),
        };
        var newLanguages = new List<Language>
        {
            await Context.Languages.FirstAsync(d => d.Title == "Russian"),
        };

        var newGrade = await Context.Grades.FirstAsync(g => g.GradeNumber == 10);

        var handler = new UpdateClassCommandHandler(Context, mediatorMock.Object );

        // Act
        await handler.Handle(new UpdateClassCommand()
        {
            ClassId = @class.ClassId,
            Title = newTitle,
            PhotoUrl = newPhotoUrl,
            Disciplines = newDisciplines,
            Languages = newLanguages,
            GradeNumber = newGrade.GradeNumber,
        }, CancellationToken.None);

        // Assert
        var result = await Context.Classes.FirstOrDefaultAsync(c =>
            c.ClassId == @class.ClassId &&
            c.Title == newTitle &&
            c.PhotoUrl == newPhotoUrl &&
            c.Grade == newGrade &&
            c.ClassDisciplines.Count() == newDisciplines.Count() &&
            c.ClassLanguages.Count == newLanguages.Count);

        Assert.NotNull(result);
        Assert.True(result != null 
                    && result.ClassLanguages.Select(l =>
                l.Language)
                         
            .SequenceEqual(newLanguages));
        Assert.True(result != null 
                    && result.ClassDisciplines.Select(d =>
                d.Discipline)
            .SequenceEqual(newDisciplines));
    }
}