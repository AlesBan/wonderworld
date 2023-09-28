using Application.UnitTests.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Mappings;
using Wonderworld.Application.Dtos.SearchDtos;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListByDefaultSearchRequest;
using Wonderworld.Domain.Entities.Education;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.UserHandlers.Queries;

public class GetUserProfileListByDefaultSearchQueryCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task Handle_GetUserProfileList_ReturnsUserProfileDtoList()
    {
        // Arrange
        var discipline1 = Context.Disciplines.SingleAsync(d => d
            .Title == "Mathematics").Result;
        var discipline2 = Context.Disciplines.SingleAsync(d => d
            .Title == "Chemistry").Result;

        var searchRequest = new DefaultSearchRequestDto
        {
            Disciplines = new List<Discipline> { discipline1, discipline2 },
            Country = Context.Countries.SingleAsync(c => c
                .Title == "CountryA").Result
        };

        var command = new GetUserProfileListByDefaultSearchRequestCommand
        {
            SearchRequest = searchRequest
        };

        var cancellationToken = new CancellationToken();

        var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<AssemblyMappingProfile>(); });

        var mapper = mapperConfiguration.CreateMapper();

        var handler = new GetUserProfileListByDefaultSearchRequestCommandHandler(Context, mapper);

        // Act
        var result = await handler.Handle(command, cancellationToken);

        // Assert
        Assert.NotNull(result);
    }
}