using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Handlers.CityHandlers.Commands.CreateCity;
using Xunit;

namespace Application.UnitTests.Handlers.CityHandlers.Commands;

public class CreateCityCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task CreateCityCommandHandler_Handle_ShouldCreateCity()
    {
        // Arrange
        var countryId = SharedLessonDbContextFactory.CountryAId;
        var handler = new CreateCityCommandHandler(Context);

        // Act
        var cityId = await handler.Handle(new CreateCityCommand()
        {
            CountryId = countryId,
            Title = "City"
        }, CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Cities.SingleOrDefaultAsync(c =>
            c.CityId == cityId &&
            c.Title == "City" &&
            c.CountryId == countryId));
    }
}