using Application.UnitTests.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using Wonderworld.Application.Common.Mappings;
using Wonderworld.Application.Handlers.UserHandlers.Commands.RegisterUser;
using Wonderworld.Domain.Entities.Main;
using Xunit;

namespace Application.UnitTests.Handlers.UserHandlers.Commands.RegisterUserAccount;

public class RegisterUserCommandHandlerTests : TestCommonBase
{
    private readonly Mock<IMapper> _mockMapper;

    public RegisterUserCommandHandlerTests()
    {
        _mockMapper = new Mock<IMapper>();
    }

    [Fact]
    public async Task RegisterUserCommandHandler_Success()
    {
        // Arrange
        const string email = "request.Email";
        const string password = "request.Password";
        _mockMapper.Setup(x =>
                x.Map<User>(It.IsAny<RegisterUserCommand>()))
            .Returns(
                new User()
                {
                    Email = email,
                    Password = password
                });
        var handler = new RegisterUserCommandHandler(Context, _mockMapper.Object);

        // Act
        var userId = await handler.Handle(new RegisterUserCommand()
            {
                Email = email,
                Password = password
            },
            CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Users.SingleOrDefaultAsync(u =>
            u.UserId == userId && u.Email == email && u.Password == password));
    }
}