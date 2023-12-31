// using Application.UnitTests.Common;
// using Microsoft.EntityFrameworkCore;
// using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.RegisterUser;
// using Xunit;
//
// namespace Application.UnitTests.Handlers.EntityHandlers.UserHandlers.Commands;
//
// public class RegisterUserCommandHandlerTests : TestCommonBase
// {
//     [Fact]
//     public async Task RegisterUserCommandHandler_Handle_ShouldRegisterUser()
//     {
//         // Arrange
//         const string email = "request.Email";
//         const string password = "request.Password";
//         
//         var handler = new RegisterUserCommandHandler(Context);
//
//         // Act
//         var user = await handler.Handle(new RegisterUserCommand(email, password), CancellationToken.None);
//
//         // Assert
//         Assert.NotNull(user);
//         Assert.NotNull(await Context.Users.SingleOrDefaultAsync(u =>
//             u.UserId == user.UserId &&
//             u.Email == email && 
//             u.Password == password));
//     }
// }