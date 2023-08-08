using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
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
        const int newAge = 16;

        var handler = new UpdateClassCommandHandler(Context);

        // Act
        await handler.Handle(new UpdateClassCommand()
        {
            Class = await Context.Classes.FirstAsync(c => c.ClassId == SharedLessonDbContextFactory.ClassForUpdateId),
            Title = newTitle,
            PhotoUrl = newPhotoUrl,
            Disciplines = newDisciplines,
            Languages = newLanguages,
            Grade = newGrade,
            Age = newAge,
        }, CancellationToken.None);

        // Assert
        var result = await Context.Classes.FirstOrDefaultAsync(c =>
            c.ClassId == @class.ClassId &&
            c.Title == newTitle &&
            c.PhotoUrl == newPhotoUrl &&
            c.Grade == newGrade &&
            c.Age == newAge &&
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