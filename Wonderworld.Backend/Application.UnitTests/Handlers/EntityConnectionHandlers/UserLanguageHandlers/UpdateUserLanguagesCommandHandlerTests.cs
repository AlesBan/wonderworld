using Application.UnitTests.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
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
        var mediatorMock = new Mock<IMediator>();
        var user = await Context.Users
            .SingleOrDefaultAsync(x =>
                x.UserId == SharedLessonDbContextFactory.UserAId);
        var newLanguages = new List<Language>()
        {
            Context.Languages.SingleAsync(x =>
                x.Title == "English").Result
        };
        var handler = new UpdateUserLanguagesCommandHandler(Context, mediatorMock.Object);

        // Act
        await handler.Handle(new UpdateUserLanguagesCommand()
        {
            UserId = user!.UserId,
            NewLanguageIds = newLanguages.Select(l => l.LanguageId).ToList()
        }, CancellationToken.None);

        // Assert
        Assert.Equal(1, Context.UserLanguages.Count(ug => ug.UserId == user!.UserId));
        Assert.NotEmpty(Context.UserLanguages
            .Where(ug => ug.UserId == user!.UserId &&
                         ug.Language.Title == "English"));
    }
}