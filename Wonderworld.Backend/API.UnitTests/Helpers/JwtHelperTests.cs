using Microsoft.Extensions.Configuration;
using Wonderworld.API.Helpers.JwtHelpers;
using Wonderworld.Domain.Entities.Main;
using Xunit;

namespace API.UnitTests.Helpers;

public class JwtHelperTests
{
    [Fact]
    public Task JwtHelperTests_CreateToken_ShouldReturnToken()
    {
        // Arrange
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Email = "John@amogus", 
            Password = "123"
        };
        
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.test.json")
            .AddUserSecrets(typeof(JwtHelperTests).Assembly)
            .AddEnvironmentVariables()
            .Build();
        
        //Act
        var token = JwtHelper.CreateToken(user, configuration);
        
        //Assert
        Assert.NotEmpty(token);
        return Task.CompletedTask;
    }
}