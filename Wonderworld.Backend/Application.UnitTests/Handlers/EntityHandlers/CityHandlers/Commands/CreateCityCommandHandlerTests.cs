using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Handlers.EntityHandlers.CityHandlers.Commands.CreateCity;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.CityHandlers.Commands;

public class CreateCityCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task CreateCityCommandHandler_Handle_ShouldCreateCity()
    {
        // Arrange
        var country = Context.Countries
            .SingleOrDefaultAsync(c =>
                c.CountryId == SharedLessonDbContextFactory.CountryAId,
                CancellationToken.None).Result;
        var handler = new CreateCityCommandHandler(Context);

        // Act
        var city = await handler.Handle(new CreateCityCommand()
        {
            CountryId = country!.CountryId,
            Title = "City"
        }, CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Cities.SingleOrDefaultAsync(c =>
            c.CityId == city.CityId &&
            c.Title == "City" &&
            c.Country == country));
    }
}