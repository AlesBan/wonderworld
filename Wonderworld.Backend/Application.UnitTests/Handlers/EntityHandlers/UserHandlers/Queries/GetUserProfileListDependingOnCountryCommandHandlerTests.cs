using Application.UnitTests.Common;
using AutoMapper;
using Shouldly;
using Wonderworld.Application.Common.Mappings;
using Wonderworld.Application.Dtos.ProfileDtos;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListDependingOnCountry;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.UserHandlers.Queries;

public class GetUserProfileListDependingOnCountryCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task Handle_ShouldReturnUserProfileList()
    {
        // Arrange
        var countryId = SharedLessonDbContextFactory.CountryAId;
        const bool isATeacher = true;
        const bool isAnExpert = false;
        var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AssemblyMappingProfile>();
            }
        );
        
        var mapper = mapperConfiguration.CreateMapper();
        var handler = new GetUserProfileListDependingOnCountryCommandHandler(Context, mapper);
        
        // Act
        var result = await handler.Handle(new GetUserProfileListDependingOnCountryCommand()
        {
            CountryId = countryId,
            IsATeacher = isATeacher,
            IsAnExpert = isAnExpert
        }, CancellationToken.None);
        
        // Assert
        Assert.NotNull(result);
            
        result.ShouldBeOfType<List<UserProfileDto>>();
    }
}