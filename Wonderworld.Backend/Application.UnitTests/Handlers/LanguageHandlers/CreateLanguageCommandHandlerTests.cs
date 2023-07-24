using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Handlers.LanguageHandlers.Commands.CreateLanguage;
using Xunit;

namespace Application.UnitTests.Handlers.LanguageHandlers;

public class CreateLanguageCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task CreateLanguageCommandHandler_Handle_ShouldCreateUserAccount()
    {
        // Arrange
        var langTitle = "English";
        var handler = new CreateLanguageCommandHandler(Context);

        // Act
        var langId = await handler.Handle(new CreateLanguageCommand()
        {
            Title = langTitle
        }, CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Languages.SingleOrDefaultAsync(c =>
            c.LanguageId == langId &&
            c.Title == langTitle));
    }
}

