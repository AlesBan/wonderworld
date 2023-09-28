using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserLanguagesHandlers.Commands.UpdateUserLanguages;
using Wonderworld.Domain.Entities.Education;
using Xunit;

namespace Application.UnitTests.Handlers.EntityConnectionHandlers.UserLanguageHandlers;

public class UpdateUserLanguagesCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task UpdateUserLanguagesCommandHandler_Handle_ShouldUpdateUserLanguages()
    {
        // Arrange
        var user = await Context.Users
            .SingleOrDefaultAsync(x =>
                x.UserId == SharedLessonDbContextFactory.UserAId);
        var newLanguages = new List<Language>()
        {
            Context.Languages.SingleAsync(x =>
                x.Title == "English").Result
        };
        var handler = new UpdateUserLanguagesQueryHandler(Context);

        // Act
        await handler.Handle(new UpdateUserLanguagesQuery()
        {
            UserId = user!.UserId,
            NewLanguages = newLanguages.Select(l => l.LanguageId).ToList()
        }, CancellationToken.None);

        // Assert
        Assert.Equal(1, Context.UserLanguages.Count(ug => ug.UserId == user!.UserId));
        Assert.NotEmpty(Context.UserLanguages
            .Where(ug => ug.UserId == user!.UserId &&
                         ug.Language.Title == "English"));
    }
}