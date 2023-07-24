using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Handlers.CityHandlers.Commands.DeleteCity;
using Wonderworld.Application.Handlers.EstablishmentHandlers.Commands.DeleteEstablishment;
using Xunit;

namespace Application.UnitTests.Handlers.EstablishmentHandlers.Commands;

public class DeleteEstablishmentCommandHandlerTests: TestCommonBase
{
    [Fact]
    public async Task DeleteEstablishmentCommandHandler_Handle_ShouldDeleteEstablishment()
    {
        // Arrange
        var establishmentId = SharedLessonDbContextFactory.EstablishmentForDeleteId;
        var handler = new DeleteEstablishmentCommandHandler(Context);
        
        // Act
        await handler.Handle(new DeleteEstablishmentCommand()
            {
                EstablishmentId = establishmentId
            }, 
            CancellationToken.None);
        
        // Assert
        Assert.Null(await Context.Establishments
            .SingleOrDefaultAsync(e => 
            e.EstablishmentId == establishmentId));
    }
    
    [Fact]
    public async Task DeleteEstablishmentCommandHandler_Handle_FailOnWrongId()
    {
        // Arrange
        var handler = new DeleteEstablishmentCommandHandler(Context);

        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new DeleteEstablishmentCommand { EstablishmentId = Guid.NewGuid() },
                CancellationToken.None));
    }
}