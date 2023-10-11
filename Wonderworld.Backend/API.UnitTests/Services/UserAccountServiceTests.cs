using API.UnitTests.Common;
using Application.UnitTests.Common;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Wonderworld.API.Services.AccountServices;
using Wonderworld.Application.Common.Exceptions.User;
using Wonderworld.Application.Dtos.UserDtos.AuthenticationDtos;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.RegisterUser;
using Wonderworld.Domain.Entities.Main;
using Xunit;

namespace API.UnitTests.Services;

public class UserAccountServiceTests : TestCommonBase, IClassFixture<TestSetup>
{
    private readonly IConfigurationRoot _configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile(
            path: "appsettings.test.json",
            optional: false,
            reloadOnChange: true)
        .Build();

    [Fact]
    public async Task RegisterUser_ValidRequest_ReturnsOkResultWithToken()
    {
        // Arrange
        var requestUserDto = new UserRegisterRequestDto
        {
            Email = "exampleEmail@gmail.com",
            Password = "exampleEmail",
        };

        var mediatorMock = new Mock<IMediator>();
        var user = new User();
        mediatorMock.Setup(m => m.Send(It.IsAny<RegisterUserCommand>(),
            It.IsAny<CancellationToken>())).ReturnsAsync(user);

        var mapper = new Mock<IMapper>();
        var service = new UserAccountService(Context, _configuration, mapper.Object);

        // Act
        var result = await service.RegisterUser(requestUserDto, mediatorMock.Object);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task RegisterUser_InvalidRequest_ReturnsBadRequestResult()
    {
        // Arrange
        var requestUserDto = new UserRegisterRequestDto
        {
            Email = "exampleEmail@gmail.com",
            Password = "exampleEmail",
        };

        var mediatorMock = new Mock<IMediator>();
        var user = new User()
        {
            Email = "exampleEmail",
        };
        mediatorMock.Setup(m => m.Send(It.IsAny<RegisterUserCommand>(),
            It.IsAny<CancellationToken>())).ThrowsAsync(new UserAlreadyExistsException(user.Email));

        var mapper = new Mock<IMapper>();
        var service = new UserAccountService(Context, _configuration, mapper.Object);

        // Act
        // Assert
        await Assert.ThrowsAsync<UserAlreadyExistsException>(async () =>
            await service.RegisterUser(requestUserDto, mediatorMock.Object));
    }
}