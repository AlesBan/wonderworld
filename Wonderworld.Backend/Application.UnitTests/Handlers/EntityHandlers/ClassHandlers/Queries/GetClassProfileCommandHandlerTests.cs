using Application.UnitTests.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Wonderworld.Application.Dtos;
using Wonderworld.Application.Dtos.ClassDtos;
using Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Queries.GetClassProfile;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.ClassHandlers.Queries;
[Collection("QueryCollection")]
public class GetClassProfileCommandHandlerTests : TestCommonBase
{
    private readonly IMapper _mapper;

    public GetClassProfileCommandHandlerTests(QueryTestFixture fixture)
    {
        _mapper = fixture.Mapper;
    }

    [Fact]
    public async Task Handle_ShouldReturnClassProfile()
    {
        // Arrange
        var @class = await Context.Classes
            .SingleOrDefaultAsync(c => 
            c.ClassId == SharedLessonDbContextFactory.ClassAId);
        
        var handler = new GetClassProfileCommandHandler(_mapper);
        
        //Act
        var result = await handler.Handle(new GetClassProfileCommand
        {
            Class = @class!
        }, CancellationToken.None);
        
        // Assert
        Assert.NotNull(result);
        result.ShouldBeOfType<ClassProfileDto>();
        Assert.NotNull(result.UserFullName);
        result.UserFullName.ShouldBe(@class.User.FullName);
        Assert.NotNull(result.PhotoUrl);
        result.PhotoUrl.ShouldBe(@class.PhotoUrl);
    }
}