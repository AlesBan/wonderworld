using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Handlers.EntityHandlers.EstablishmentHandlers.Commands.CreateEstablishment;
using Wonderworld.Domain.Enums.EntityTypes;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.EstablishmentHandlers.Commands;

public class CreateEstablishmentCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task CreateEstablishmentCommandHandler_Handle_ShouldCreateEstablishment()
    {
        // Arrange
        const string address = "address";
        const string title = "Establishment1";
        var typeTitle = EstablishmentType.School.ToString();
        var type = await Context.EstablishmentTypes
            .SingleOrDefaultAsync(t => t.Title == typeTitle);

        var command = new CreateEstablishmentCommand
        {
            Title = title,
            Address = address,
            Types = new List<Wonderworld.Domain.Entities.Job.EstablishmentType> { type! }
        };

        var handler = new CreateEstablishmentCommandHandler(Context);

        // Act
        var establishment = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Establishments
            .SingleOrDefaultAsync(e =>
                e.EstablishmentId == establishment.EstablishmentId));
    }
}