using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Handlers.UserHandlers.Commands.RegisterUser;
using Wonderworld.Domain.Entities.Interface;
using Wonderworld.Domain.Enums;
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
        var interfaceLanguage = new InterfaceLanguage()
        {
            Title = InterfaceLanguages.English.ToString(),
            LanguageId = new Guid("6CF863C7-9989-4C93-AD01-5BDB9F7AFFDD")

        };
        
        var handler = new RegisterUserCommandHandler(Context);

        // Act
        var userId = await handler.Handle(new RegisterUserCommand()
            {
                Email = email,
                Password = password,
                InterfaceLanguage = interfaceLanguage
            },
            CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Users.SingleOrDefaultAsync(u =>
            u.UserId == userId && 
            u.Email == email && 
            u.Password == password &&
            u.InterfaceLanguageId == interfaceLanguage.LanguageId));
    }
}