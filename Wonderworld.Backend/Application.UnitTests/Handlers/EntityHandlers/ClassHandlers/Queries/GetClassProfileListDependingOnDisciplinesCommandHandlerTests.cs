using Application.UnitTests.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Wonderworld.Application.Common.Mappings;
using Wonderworld.Application.Dtos.ProfileDtos;
using Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Queries.GetClassProfileListDependingOnDisciplines;
using Wonderworld.Domain.Entities.Education;
using Xunit;

namespace Application.UnitTests.Handlers.EntityHandlers.ClassHandlers.Queries;

public class GetClassProfileListDependingOnDisciplinesCommandHandlerTests : TestCommonBase
{
    [Fact]
    public async Task Handle_ShouldReturnClassProfileListDependingOnDisciplines()
    {
        // Arrange
        var discipline1 = await Context.Disciplines.FirstAsync(d =>
            d.Title == "Mathematics");
        var discipline2 = await Context.Disciplines.FirstAsync(d =>
            d.Title == "Chemistry");

        var disciplines = new List<Discipline>()
        {
            discipline1, discipline2
        };
        var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<AssemblyMappingProfile>(); });
        var mapper = mapperConfiguration.CreateMapper();
        var handler = new GetClassProfileListDependingOnDisciplinesCommandHandler(Context, mapper);
        
        // Act
        var result = await handler.Handle(new GetClassProfileListDependingOnDisciplinesCommand()
        {
            Disciplines = disciplines
        }, CancellationToken.None);
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count());
        result.ShouldBeOfType<List<ClassProfileDto>>();
            
        }
    }