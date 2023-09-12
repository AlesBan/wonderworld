using Application.UnitTests.Common;
using AutoMapper;
using Shouldly;
using Wonderworld.Application.Common.Mappings;
using Wonderworld.Application.Dtos.ProfileDtos;
using Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Queries.GetClassProfileListDependingOnCountry;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.ClassHandlers.Queries;

public class GetClassProfileListDependingOnCountryCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task Handle_ShouldReturnClassProfileListDependingOnCountry()
    {
        // Arrange
        var countryId = SharedLessonDbContextFactory.CountryAId;

        var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<AssemblyMappingProfile>(); });
        var mapper = mapperConfiguration.CreateMapper();
        var handler = new GetClassProfileListDependingOnCountryCommandHandler(Context, mapper);

        // Act
        var result = await handler.Handle(new GetClassProfileListDependingOnCountryCommand()
        {
            CountryId = countryId
        }, CancellationToken.None);

        // Assert
        Assert.NotNull(result);

        result.ShouldBeOfType<List<ClassProfileDto>>();
    }
}