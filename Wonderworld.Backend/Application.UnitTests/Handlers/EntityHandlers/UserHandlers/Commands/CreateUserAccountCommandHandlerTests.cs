using Application.UnitTests.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.CreateUserAccount;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.UserHandlers.Commands;

public class CreateUserAccountCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task CreateUserAccountCommand_Handle_ShouldCreateUserAccount()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();

        var user = await Context.Users.SingleOrDefaultAsync(u =>
            u.UserId == SharedLessonDbContextFactory.UserRegisteredId);
        const string firstName = "FirstName";
        const string lastName = "LastName";
        const bool isATeacher = true;
        const bool isAnExpert = false;
        var cityLocation = Context.Cities.FirstOrDefault(c =>
            c.CityId == SharedLessonDbContextFactory.CityAId);

        var establishment = Context.Institutions.FirstOrDefault(e =>
            e.InstitutionId == SharedLessonDbContextFactory.EstablishmentAId);
        var disciplines = Extensions.PickRandom(Context.Disciplines.ToList(), 3).ToList();
        var languages = Extensions.PickRandom(Context.Languages.ToList(), 2).ToList();
        const string photoUrl = "PhotoUrl";

        var createUserAccountCommand = new CreateUserAccountCommand()
        {
            UserId = user.UserId,
            FirstName = firstName,
            LastName = lastName,
            IsATeacher = isATeacher,
            IsAnExpert = isAnExpert,
            City = cityLocation!,
            Institution = establishment!,
            Disciplines = disciplines,
            Languages = languages,
            PhotoUrl = photoUrl
        };


        // Act
        var handler = new CreateUserAccountCommandHandler(Context, mediatorMock.Object);
        await handler.Handle(createUserAccountCommand,
            CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Users.SingleOrDefaultAsync(u =>
            u.UserId == user!.UserId &&
            u.FirstName == firstName &&
            u.LastName == lastName &&
            u.IsATeacher == isATeacher &&
            u.IsAnExpert == isAnExpert &&
            u.City == cityLocation &&
            u.Institution == establishment &&
            u.UserDisciplines.Count() == disciplines.Count() &&
            u.UserLanguages.Count() == languages.Count() &&
            u.PhotoUrl == photoUrl));
    }
}