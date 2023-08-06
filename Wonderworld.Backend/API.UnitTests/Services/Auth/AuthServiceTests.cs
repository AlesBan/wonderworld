using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using Wonderworld.API.Services.Auth;
using Wonderworld.Domain.Entities.Main;
using Xunit;

namespace API.UnitTests.Services.Auth;

public class AuthServiceTests
{
    [Fact]
    public void SetToken_ShouldSetToken()
    {
        // Arrange
        var user = new User
        {
            UserId = Guid.NewGuid(),
            FirstName = "John", 
            LastName = "Doe"
        };
        
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.test.json")
            .AddUserSecrets(typeof(AuthServiceTests).Assembly)
            .AddEnvironmentVariables()
            .Build();
        
        var mockContext = new Mock<HttpContext>();
        var mockSession = new Mock<ISession>();

        mockContext.SetupGet(x => x.Session)
            .Returns(mockSession.Object);
        
        var service = new AuthService();
        
        // Act
        service.SetToken(user, mockContext.Object, configuration);
        
        // Assert
        var keys = mockContext.Object.Items;
        mockSession.Verify(x => x
            .Set("Authorization", It.IsAny<byte[]>()), Times.Once);
    }
    
}