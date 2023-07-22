// using Application.UnitTests.Common;
// using Microsoft.EntityFrameworkCore;
// using Wonderworld.Application.Handlers.UserHandlers.Commands.DeleteUser;
// using Wonderworld.Domain.Entities.Interface;
// using Wonderworld.Domain.Enums;
// using Xunit;
//
// namespace Application.UnitTests.Handlers.UserHandlers.Commands;
//
// public class DeleteUserCommandHandlerTests : TestCommonBase
// {
//     [Fact]
//     public async Task Handle_ShouldDeleteUser()
//     {
//         // Arrange
//         const string email = "request.Email";
//         const string password = "request.Password";
//         var interfaceLanguage = new InterfaceLanguage()
//         {
//             Title = InterfaceLanguages.English.ToString(),
//             LanguageId = new Guid("6CF863C7-9989-4C93-AD01-5BDB9F7AFFDD")
//         };
//
//         var handler = new DeleteUserCommandHandler(Context);
//
//         // Act
//         var userId = await handler.Handle(new DeleteUserCommand()
//         {
//             UserId = 1,
//         }, CancellationToken.None);
//
//         // Assert
//         Assert.Null(await Context.Users.SingleOrDefaultAsync(u =>
//             u.UserId == userId &&
//             u.Email == email &&
//             u.Password == password &&
//             u.InterfaceLanguageId == interfaceLanguage.LanguageId));
//     }
//
// }