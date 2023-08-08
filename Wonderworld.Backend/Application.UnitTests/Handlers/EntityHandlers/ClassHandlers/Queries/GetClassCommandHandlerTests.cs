using Application.UnitTests.Common;
using Shouldly;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Queries.GetClass;
using Wonderworld.Domain.Entities.Main;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.ClassHandlers.Queries;

public class GetClassCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task Handle_ShouldReturnClass()
    {
        // Arrange
        var classId = SharedLessonDbContextFactory.ClassAId;
        var handler = new GetClassCommandHandler(Context);

        // Act
        var result = await handler.Handle(new GetClassCommand
        {
            ClassId = classId
        }, CancellationToken.None);

        // Assert
        result.ShouldBeOfType<Class>();
        result.ClassId.ShouldBe(classId);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Handle_ShouldThrowNotFoundException()
    {
        // Arrange
        var classId = Guid.NewGuid();
        var handler = new GetClassCommandHandler(Context);

        // Act
        await Should.ThrowAsync<NotFoundException>(async () =>
            await handler.Handle(new GetClassCommand
            {
                ClassId = classId
            }, CancellationToken.None));
    }
}