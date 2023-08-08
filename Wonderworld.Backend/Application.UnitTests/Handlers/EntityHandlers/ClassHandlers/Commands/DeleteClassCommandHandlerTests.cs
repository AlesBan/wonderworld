using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Commands.DeleteClass;
using Wonderworld.Persistence;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.ClassHandlers.Commands;

public class DeleteClassCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task DeleteClassCommand_Handle_ShouldDeleteClass()
    {
        // Arrange
        var handler = new DeleteClassCommandHandler(Context);

        // Act
        await handler.Handle(new DeleteClassCommand()
        {
            Class = await Context.Classes.FirstAsync(c =>
                c.ClassId == SharedLessonDbContextFactory.ClassForDeleteId),
        }, CancellationToken.None);
        
        // Assert
        Assert.Null(await Context.Classes.SingleOrDefaultAsync(c =>
            c.ClassId == SharedLessonDbContextFactory.ClassForDeleteId));
    }
}