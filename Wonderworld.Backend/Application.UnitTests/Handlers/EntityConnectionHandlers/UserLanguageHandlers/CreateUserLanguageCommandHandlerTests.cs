using Application.UnitTests.Common;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserLanguagesHandlers.Commands.CreateUserLanguages;
using Wonderworld.Domain.Entities.Education;
using Xunit;

namespace Application.UnitTests.Handlers.EntityConnectionHandlers.UserLanguageHandlers;

public class CreateUserLanguageCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task CreateUserLanguagesCommandHandler_Handle_ShouldCreateUserLanguages()
    {
        // Arrange
        var user = Context.Users.SingleOrDefault(x =>
            x.UserId == SharedLessonDbContextFactory.UserRegisteredId);
        var language = Context.Languages.SingleOrDefault(x => x.Title == "English")!;

        var handler = new CreateUserLanguageCommandHandler(Context);

        // Act
        await handler.Handle(new CreateUserLanguageCommand()
        {
            User = user!,
            Language = language
        }, CancellationToken.None);

        // Assert
        Assert.NotEmpty(Context.UserLanguages
            .Where(ud => ud.UserId == user!.UserId &&
                         ud.Language.Title == language.Title));
    }
}