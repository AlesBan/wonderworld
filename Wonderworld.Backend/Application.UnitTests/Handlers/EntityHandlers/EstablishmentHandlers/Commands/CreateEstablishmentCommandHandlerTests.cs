using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Handlers.EstablishmentHandlers.Commands.CreateEstablishment;
using Wonderworld.Domain.Enums;
using Wonderworld.Domain.Enums.EntityTypes;
using Xunit;

namespace Application.UnitTests.Handlers.EstablishmentHandlers.Commands;

public class CreateEstablishmentCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task CreateEstablishmentCommandHandler_Handle_ShouldCreateEstablishment()
    {
        // Arrange
        var city = Context.Cities
            .SingleOrDefaultAsync(c =>
                    c.CityId == SharedLessonDbContextFactory.CityAId,
                CancellationToken.None).Result;
        const string title = "Establishment1";
        var type = EstablishmentType.School.ToString();
        
        var command = new CreateEstablishmentCommand
        {
            Title = title,
            City = city!,
            Type = type
        };

        var handler = new CreateEstablishmentCommandHandler(Context);

        // Act
        var establishmentId = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Establishments
            .SingleOrDefaultAsync(e =>
                e.EstablishmentId == establishmentId));
    }
}