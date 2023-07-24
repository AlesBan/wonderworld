using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Handlers.LanguageHandlers.Commands.DeleteLanguage;
using Xunit;

namespace Application.UnitTests.Handlers.LanguageHandlers;

public class DeleteLanguageCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task DeleteLanguageCommandHandler_Handle_ShouldCreateUserAccount()
    {
        // Arrange
        var langId = SharedLessonDbContextFactory.LanguageForDeleteId;
        var handler = new DeleteLanguageCommandHandler(Context);

        // Act
        await handler.Handle(new DeleteLanguageCommand { LanguageId = langId },
            CancellationToken.None);

        // Assert
        Assert.Null(await Context.Languages.SingleOrDefaultAsync(c =>
            c.LanguageId == langId));
    }

    [Fact]
    public async Task DeleteLanguageCommandHandler_Handle_FailOnWrongId()
    {
        // Arrange
        var handler = new DeleteLanguageCommandHandler(Context);

        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new DeleteLanguageCommand { LanguageId = Guid.NewGuid() },
                CancellationToken.None));
    }
}