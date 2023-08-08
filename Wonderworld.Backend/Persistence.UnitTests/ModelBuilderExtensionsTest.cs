using System.Runtime.CompilerServices;
using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Persistence.UnitTests;

public class ModelBuilderExtensionsTest : TestCommonBase
{
    [Fact]
    public async Task SeedingDefaultData_ShouldSeed()
    {
        // Arrange

        // Act

        // Assert
        Assert.NotEmpty(await Context.Disciplines.ToListAsync());
        Assert.NotEmpty(await Context.Languages.ToListAsync());
        Assert.NotEmpty(await Context.Roles.ToListAsync());
        Assert.Equal(12, await Context.Grades.CountAsync());
    }
}