using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Common.Exceptions.Common;
using Wonderworld.Application.Common.Exceptions.Database;
using Wonderworld.Application.Handlers.CountryHandlers.Commands.DeleteCountry;
using Wonderworld.Application.Handlers.EntityHandlers.CityHandlers.Commands.DeleteCity;
using Xunit;

namespace Application.UnitTests.Handlers.CityHandlers.Commands;

public class DeleteCityCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task DeleteCityCommandHandler_Handle_ShouldDeleteCity()
    {
        // Arrange
        var cityId = SharedLessonDbContextFactory.CityForDeleteId;
        var handler = new DeleteCityCommandHandler(Context);
        
        // Act
        await handler.Handle(new DeleteCityCommand { CityId = cityId }, 
            CancellationToken.None);
        
        // Assert
        Assert.Null(await Context.Cities.SingleOrDefaultAsync(c => c.CityId == cityId));
    }
    
    [Fact]
    public async Task DeleteCityCommandHandler_Handle_FailOnWrongId()
    {
        // Arrange
        var handler = new DeleteCityCommandHandler(Context);

        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new DeleteCityCommand { CityId = Guid.NewGuid() },
                CancellationToken.None));
    }
}