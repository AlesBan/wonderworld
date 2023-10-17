using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wonderworld.Application.Dtos.ClassDtos;
using Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Commands.CreateClass;
using Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Commands.DeleteClass;
using Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Commands.UpdateClass;
using Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Queries.GetClass;
using Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplinesByTitles;
using Wonderworld.Application.Handlers.EntityHandlers.LanguageHandlers.Queries.GetLanguagesByTitles;

namespace Wonderworld.API.Services.ClassServices;

public class ClassService : IClassService
{
    private readonly IMapper _mapper;

    public ClassService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<IActionResult> CreateClass(Guid userId, CreateClassRequestDto requestClassDto, IMediator mediator)
    {
        var disciplines = await mediator.Send(new GetDisciplinesByTitlesQuery(requestClassDto.DisciplineTitles),
            CancellationToken.None);
        var languages = await mediator.Send(new GetLanguagesByTitlesQuery(requestClassDto.LanguageTitles),
            CancellationToken.None);

        var command = new CreateClassCommand
        {
            UserId = userId,
            Title = requestClassDto.Title,
            GradeNumber = requestClassDto.GradeNumber,
            DisciplineIds = disciplines.Select(d => d.DisciplineId).ToList(),
            LanguageIds = languages.Select(l => l.LanguageId).ToList(),
            PhotoUrl = requestClassDto.PhotoUrl
        };

        var @class = await mediator.Send(command, CancellationToken.None);

        await Task.Delay(20);

        var classProfile = _mapper.Map<ClassProfileDto>(@class);

        await Task.Delay(20);

        classProfile.Languages = @class.ClassLanguages.Select(cl => cl.Language.Title).ToList();
        classProfile.Disciplines = @class.ClassDisciplines.Select(cd => cd.Discipline.Title).ToList();
        
        return new OkObjectResult(classProfile);
    }

    public async Task<IActionResult> GetClassProfile(Guid classId, IMediator mediator)
    {
        var command = new GetClassCommand(classId);

        var @class = await mediator.Send(command);

        await Task.Delay(20);

        var classProfile = _mapper.Map<ClassProfileDto>(@class);

        await Task.Delay(20);

        classProfile.Languages = @class.ClassLanguages.Select(cl => cl.Language.Title).ToList();
        classProfile.Disciplines = @class.ClassDisciplines.Select(cd => cd.Discipline.Title).ToList();
        
        return new OkObjectResult(classProfile);
    }

    public async Task<IActionResult> UpdateClass(Guid classId, UpdateClassRequestDto requestClassDto,
        IMediator mediator)
    {
        var command = new UpdateClassCommand
        {
            ClassId = classId,
            Title = requestClassDto.Title,
            GradeNumber = requestClassDto.GradeNumber,
            DisciplineTitles = requestClassDto.DisciplineTitles,
            LanguageTitles = requestClassDto.LanguageTitles,
            PhotoUrl = requestClassDto.PhotoUrl
        };

        var @class = await mediator.Send(command, CancellationToken.None);
        
        await Task.Delay(20);

        var classProfile = _mapper.Map<ClassProfileDto>(@class);

        await Task.Delay(20);

        classProfile.Languages = @class.ClassLanguages.Select(cl => cl.Language.Title).ToList();
        classProfile.Disciplines = @class.ClassDisciplines.Select(cd => cd.Discipline.Title).ToList();

        return new OkObjectResult(classProfile);
    }

    public async Task<IActionResult> DeleteClass(Guid classId, IMediator mediator)
    {
        var command = new DeleteClassCommand(classId);
        await mediator.Send(command, CancellationToken.None);

        return new OkResult();
    }
}