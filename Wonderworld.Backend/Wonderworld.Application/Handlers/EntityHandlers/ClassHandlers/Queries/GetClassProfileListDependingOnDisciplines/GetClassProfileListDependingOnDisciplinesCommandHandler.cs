using AutoMapper;
using MediatR;
using Wonderworld.Application.Constants;
using Wonderworld.Application.Dtos.ProfileDtos;
using Wonderworld.Application.Interfaces;

namespace Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Queries.
    GetClassProfileListDependingOnDisciplines;

public class GetClassProfileListDependingOnDisciplinesCommandHandler : IRequestHandler<
    GetClassProfileListDependingOnDisciplinesCommand, IEnumerable<ClassProfileDto>>
{
    private readonly ISharedLessonDbContext _context;
    private readonly IMapper _mapper;

    public GetClassProfileListDependingOnDisciplinesCommandHandler(ISharedLessonDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<IEnumerable<ClassProfileDto>> Handle(GetClassProfileListDependingOnDisciplinesCommand request,
        CancellationToken cancellationToken)
    {
        var disciplinesIds = request.Disciplines
            .Select(d => d.DisciplineId);

        var classes = _context.Classes
            .Where(c =>
                c.ClassDisciplines.Any(d =>
                    disciplinesIds.Contains(d.DisciplineId)))
            .Take(QueryConstants.SearchClassCount)
            .ToList();

        var classProfileDtos = classes.Select(c =>
                _mapper.Map<ClassProfileDto>(c))
            .ToList();

        return Task.FromResult<IEnumerable<ClassProfileDto>>(classProfileDtos);
    }
}