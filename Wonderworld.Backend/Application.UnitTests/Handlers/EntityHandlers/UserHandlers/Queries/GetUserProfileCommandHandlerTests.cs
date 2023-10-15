using Application.UnitTests.Common;
using AutoMapper;
using Shouldly;
using Wonderworld.Application.Dtos.UserDtos;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetProfileUser;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.UserHandlers.Queries;

[Collection("QueryCollection")]
public class GetUserProfileCommandHandlerTests : TestCommonBase
{
    private readonly IMapper _mapper;

    public GetUserProfileCommandHandlerTests(QueryTestFixture fixture)
    {
        _mapper = fixture.Mapper;
    }

    [Fact]
    public async Task Handle_ShouldReturnProfileUser()
    {
        // Arrange
        var user = Context.Users.SingleOrDefault(u =>
            u.UserId == SharedLessonDbContextFactory.UserAId);
        var handler = new GetUserProfileCommandHandler(_mapper);

        // Act
        var result = await handler.Handle(new GetUserProfileCommand()
        {
            User = user!
        }, CancellationToken.None);

        // Assert
        result.ShouldBeOfType<UserProfileDto>();
        result.Email.ShouldBe("emailA");
        result.FirstName.ShouldBe("FirstNameA");
        result.LastName.ShouldBe("LastNameA");
        result.IsATeacher.ShouldBe(true);
        result.IsAnExpert.ShouldBe(false);
        result.CityTitle.ShouldBe("CityA");  
        result.Institution.Title.ShouldBe("EstablishmentA");
        result.Description.ShouldBe("DescriptionA");
        result.PhotoUrl.ShouldBe("PhotoUrlA");
        result.BannerPhotoUrl.ShouldBe("BannerPhotoUrlA");
        result.ClasseDtos.Count().ShouldBe(3);
        result.Languages.Count.ShouldBe(3);
        result.Disciplines.Count.ShouldBe(2);
        result.Reviews.Count.ShouldBe(1);
        Assert.NotNull(result);
    }
}