using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Handlers.EntityHandlers.CountryHandlers.Commands.CreateCountry;
using Xunit;

namespace Application.UnitTests.Handlers.CountryHandlers.Commands;

public class CreateCountryCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task CreateCountryCommandHandler_Handle_ShouldCreateCountry()
    {
        // Arrange
        const string countryTitle = "Country";

        var handler = new CreateCountryCommandHandler(Context);

        // Act
        var countryId = await handler.Handle(new CreateCountryCommand()
        {
            Title = countryTitle
        }, CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Countries.SingleOrDefaultAsync(c =>
            c.CountryId == countryId &&
            c.Title == countryTitle));
    }
}