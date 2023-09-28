using Application.UnitTests.Common;
using AutoMapper;
using Wonderworld.Application.Common.Mappings;
using Wonderworld.Application.Dtos.SearchDtos;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListBySearchRequest;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.UserHandlers.Queries;

public class GetUserProfileListBySearchQueryCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task Handle_GetUserProfileListDependingOnSearchQueryCommand_ReturnsUserProfileDtos()
    {
        // Arrange
        var searchRequest = new SearchRequestDto()
        {
            Countries = new List<string> { "CountryA", "CountryB" },
            Grades = new List<string> { "10" },
            Disciplines = new List<string> { "Mathematics", "Chemistry" },
            Languages = new List<string> { "English", "Russian" }
        };
        var command = new GetUserProfileListBySearchRequestCommand()
        {
            SearchRequest = searchRequest
        };
        var cancellationToken = new CancellationToken();

        var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<AssemblyMappingProfile>(); });

        var mapper = mapperConfiguration.CreateMapper();

        var handler = new GetUserProfileListBySearchRequestCommandHandler(Context, mapper);

        // Act
        var result = await handler.Handle(command, cancellationToken);

        // Assert
        Assert.NotNull(result);
    }
}