using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Handlers.UserHandlers.Commands.RegisterUser;
using Xunit;

namespace Application.UnitTests.Handlers.UserHandlers.Commands;

public class RegisterUserCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task RegisterUserCommandHandler_Handle_ShouldRegisterUser()
    {
        // Arrange
        const string email = "request.Email";
        const string password = "request.Password";
        
        var handler = new RegisterUserCommandHandler(Context);

        // Act
        var userId = await handler.Handle(new RegisterUserCommand()
            {
                Email = email,
                Password = password,
            },
            CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Users.SingleOrDefaultAsync(u =>
            u.UserId == userId && 
            u.Email == email && 
            u.Password == password));
    }
}