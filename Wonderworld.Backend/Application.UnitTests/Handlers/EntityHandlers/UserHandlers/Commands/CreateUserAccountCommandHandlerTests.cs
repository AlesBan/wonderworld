using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Handlers.UserHandlers.Commands.CreateUserAccount;
using Xunit;

namespace Application.UnitTests.Handlers.UserHandlers.Commands;

public class CreateUserAccountCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task CreateUserAccountCommand_Handle_ShouldCreateUserAccount()
    {
        // Arrange
        var userId = SharedLessonDbContextFactory.UserRegisteredId;
        const string firstName = "FirstName";
        const string lastName = "LastName";
        const bool isATeacher = true;
        const bool isAnExpert = false;
        var cityLocation = Context.Cities.FirstOrDefault(c =>
            c.CityId == SharedLessonDbContextFactory.CityAId);

        var establishment = Context.Establishments.FirstOrDefault(e =>
            e.EstablishmentId == SharedLessonDbContextFactory.EstablishmentAId);
        var disciplines =Extensions.PickRandom(Context.Disciplines.ToList(), 3).ToList();

        const string photoUrl = "PhotoUrl";

        var createUserAccountCommand = new CreateUserAccountCommand()
        {
            UserId = userId,
            FirstName = firstName,
            LastName = lastName,
            IsATeacher = isATeacher,
            IsAnExpert = isAnExpert,
            CityLocation = cityLocation!,
            Establishment = establishment!,
            Disciplines = disciplines,
            PhotoUrl = photoUrl
        };


        // Act
        var handler = new CreateUserAccountCommandHandler(Context);
        await handler.Handle(createUserAccountCommand,
            CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Users.SingleOrDefaultAsync(u =>
            u.UserId == userId &&
            u.FirstName == firstName &&
            u.LastName == lastName &&
            u.IsATeacher == isATeacher &&
            u.IsAnExpert == isAnExpert &&
            u.CityLocation == cityLocation &&
            u.Establishment == establishment &&
            u.UserDisciplines.Count() == disciplines.Count() &&
            u.PhotoUrl == photoUrl));
    }

    [Fact]
    public async Task CreateUserAccountCommand_Handle_FailOnWrongId()
    {
        // Arrange
        var handler = new CreateUserAccountCommandHandler(Context);

        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new CreateUserAccountCommand { UserId = Guid.NewGuid() },
                CancellationToken.None));
    }


}