using Wonderworld.Application.Helpers;
using Xunit;

namespace Infrastructure.UnitTests.Services;

public class FileReaderTest
{
    [Fact]
    public void GetLines_ShouldReturnListOfLines_WhenValidFilePathProvided()
    {
        // Arrange
        const string path = "../../../../../Data/Disciplines.txt";

        // Act
        var result = FileHelper.GetLines(path);

        // Assert
        Assert.NotNull(result);
    }
}