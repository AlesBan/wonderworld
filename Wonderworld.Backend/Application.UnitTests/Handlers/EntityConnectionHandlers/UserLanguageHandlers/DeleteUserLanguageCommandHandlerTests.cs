using Application.UnitTests.Common;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserLanguagesHandlers.Commands.DeleteUserLanguages;
using Wonderworld.Domain.Entities.Education;
using Xunit;

namespace Application.UnitTests.Handlers.EntityConnectionHandlers.UserLanguageHandlers;

public class DeleteUserLanguageCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task DeleteUserLanguagesCommandHandler_Handle_ShouldDeleteUserLanguages()
    {
        // Arrange
        var user = Context.Users.SingleOrDefault(x =>
            x.UserId == SharedLessonDbContextFactory.UserAId);
        var languageForDelete = Context.Languages.SingleOrDefault(x => x.Title == "English")!;

        var handler = new DeleteUserLanguageCommandHandler(Context);

        // Act
        await handler.Handle(new DeleteUserLanguageCommand
        {
            User = user!,
            Language = languageForDelete
        }, CancellationToken.None);

        // Assert
        Assert.Empty(Context.UserLanguages
            .Where(ul => ul.UserId == user!.UserId &&
                         ul.Language.Title == languageForDelete.Title));
    }

    [Fact]
    public async Task DeleteUserLanguagesCommandHandler_Handle_FailOnWrongUserId()
    {
        // Arrange
        var user = Context.Users.SingleOrDefault(x =>
            x.UserId == SharedLessonDbContextFactory.UserRegisteredId);
        var languageForDelete = Context.Languages.SingleOrDefault(x => x.Title == "English")!;

        var handler = new DeleteUserLanguageCommandHandler(Context);

        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new DeleteUserLanguageCommand
            {
                User = user!,
                Language = languageForDelete
            }, CancellationToken.None));
    }
}