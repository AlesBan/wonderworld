using Application.UnitTests.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using Wonderworld.Application.Handlers.UserHandlers.Commands.CreateUserAccount;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;
using Xunit;

namespace Application.UnitTests.Handlers.UserHandlers.Commands;

public class CreateUserAccountCommandHandlerTests : TestCommonBase
{
    private readonly Mock<IMapper> _mockMapper;

    public CreateUserAccountCommandHandlerTests()
    {
        _mockMapper = new Mock<IMapper>();
    }

    [Fact]
    public async Task CreateUserAccountCommand_Handle_ShouldCreateUserAccount()
    {
        // Arrange
        var UserId = new Guid("9D13C7FF-18E0-4C71-8DB0-B7F05B420CEA");
        const string FirstName = "request.FirstName";
        const string LastName = "request.LastName";
        const bool IsATeacher = true;
        const bool IsAnExpert = false;
        var CityLocation = new City()
        {
            CityId = new Guid("6CF863C7-9989-4C93-AD01-5BDB9F7AFFDD"),
            Title = "Toronto"
        };
        var Establishment = new Establishment()
        {
            EstablishmentId = new Guid("AA63B2BD-BC34-425D-B3C9-1C0353304374"),
            Title = "Establishment"
        };

        const string PhotoUrl = "request.PhotoUrl";

        var createUserAccountCommand = new CreateUserAccountCommand()
        {
            UserId = UserId,
            FirstName = FirstName,
            LastName = LastName,
            IsATeacher = IsATeacher,
            IsAnExpert = IsAnExpert,
            CityLocation = CityLocation,
            Establishment = Establishment,
            PhotoUrl = PhotoUrl
        };


        // Act
        var handler = new CreateUserAccountCommandHandler(Context);
        await handler.Handle(createUserAccountCommand,
            CancellationToken.None);

        // Assert
        var userN = await Context.Users.SingleOrDefaultAsync(u => u.UserId == UserId);
        Assert.NotNull(await Context.Users.SingleOrDefaultAsync(u =>
            u.UserId == UserId &&
            u.FirstName == FirstName &&
            u.LastName == LastName &&
            u.IsATeacher == IsATeacher &&
            u.IsAnExpert == IsAnExpert &&
            u.PhotoUrl == PhotoUrl &&
            u.CityLocation == CityLocation &&
            u.Establishment == Establishment &&
            u.PhotoUrl == PhotoUrl));
    }
}