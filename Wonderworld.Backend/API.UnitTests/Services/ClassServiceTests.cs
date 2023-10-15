using Application.UnitTests.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using Wonderworld.Application.Dtos.ClassDtos;
using Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Commands.CreateClass;
using Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplines;
using Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplinesByTitles;
using Wonderworld.Application.Handlers.EntityHandlers.LanguageHandlers.Queries.GetLanguagesByTitles;
using Wonderworld.Domain.Entities.Education;
using Xunit;
using static System.Threading.CancellationToken;

namespace API.UnitTests.Services;

public class ClassServiceTests : TestCommonBase
{
    [Fact]
    public async Task CreateClass_ValidRequest_ReturnsOkResult()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();

        var requestClassDto = new CreateClassRequestDto
        {
            Title = "Title",
            GradeNumber = 6,
            DisciplineTitles = new List<string> { "Chemistry" },
            LanguageTitles = new List<string> { "English" },
            PhotoUrl = "PhotoUrl"
        };

        var getDisciplinesQueryHandler = new GetDisciplinesByTitlesQueryHandler(Context);
        var getDisciplineQuery = new GetDisciplinesByTitlesQuery(requestClassDto.DisciplineTitles);
        var disciplines = await getDisciplinesQueryHandler.Handle(getDisciplineQuery, None);
        
        mediatorMock.Setup(m => m.Send(It.IsAny<GetDisciplinesByTitlesQuery>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(disciplines);
        
        var getLanguagesQueryHandler = new GetLanguagesByTitlesQueryHandler(Context);
        var getLanguageQuery = new GetLanguagesByTitlesQuery(requestClassDto.LanguageTitles);
        var languages = await getLanguagesQueryHandler.Handle(getLanguageQuery, None);

        mediatorMock.Setup(m => m.Send(It.IsAny<GetLanguagesByTitlesQuery>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(languages);

        var createClassCommandHandler = new CreateClassCommandHandler(Context, mediatorMock.Object);
        var createClassCommand = new CreateClassCommand()
        {
            UserId = SharedLessonDbContextFactory.UserAId,
            Title = requestClassDto.Title,
            GradeNumber = requestClassDto.GradeNumber,
            DisciplineIds = new List<Guid>
            {
                (await Context.Disciplines.SingleOrDefaultAsync(d => d.Title == "Chemistry"))!.DisciplineId
            },
            LanguageIds = new List<Guid>
            {
                (await Context.Languages.SingleOrDefaultAsync(l => l.Title == "English"))!.LanguageId
            },
            PhotoUrl = requestClassDto.PhotoUrl
        };

        mediatorMock.Setup(m => m.Send(It.IsAny<CreateClassCommand>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(await createClassCommandHandler.Handle(createClassCommand, None));

        // Act
    }
}