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

        var searchRequest = new DefaultSearchCommandDto
        {
            DisciplineIds = new List<Guid> { discipline1.DisciplineId, discipline2.DisciplineId },
            CountryId = Context.Countries.SingleAsync(c => c
                .Title == "CountryA").Result.CountryId
        };

        var command = new GetUserListByDefaultSearchRequestCommand
        {
            SearchRequest = searchRequest
        };

        var cancellationToken = new CancellationToken();

        var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<AssemblyMappingProfile>(); });

        var mapper = mapperConfiguration.CreateMapper();

        var handler = new GetUserListByDefaultSearchRequestCommandHandler(Context, mapper);

        // Act
        var result = await handler.Handle(command, cancellationToken);

        // Assert
        Assert.NotNull(result);
    }
}