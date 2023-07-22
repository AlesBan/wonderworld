using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Handlers.CountryHandlers.Commands.DeleteCountry;
using Xunit;

namespace Application.UnitTests.Handlers.CountryHandlers.Commands;

public class DeleteCountryCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task DeleteCountryCommandHandler_ShouldDeleteCountry()
    {
        // Arrange
        var countryId = SharedLessonDbContextFactory.CountryForDeleteId;
        var handler = new DeleteCountryCommandHandler(Context);

        // Act
        await handler.Handle(new DeleteCountryCommand { CountryId = countryId },
            CancellationToken.None);

        // Assert
        Assert.Null(await Context.Countries
            .SingleOrDefaultAsync(c =>
                c.CountryId == countryId));
    }

    [Fact]
    public async Task DeleteCountryCommandHandler_Handle_FailOnWrongId()
    {
        // Arrange
        var handler = new DeleteCountryCommandHandler(Context);

        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new DeleteCountryCommand { CountryId = Guid.NewGuid() },
                CancellationToken.None));
    }
}