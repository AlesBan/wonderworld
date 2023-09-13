using AutoMapper;
using MediatR;
using Wonderworld.Application.Constants;
using Wonderworld.Application.Dtos.ProfileDtos;
using Wonderworld.Application.Interfaces;

namespace Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Queries.GetClassProfileListDependingOnCountry;

public class GetClassProfileListDependingOnCountryCommandHandler : IRequestHandler
    <GetClassProfileListDependingOnCountryCommand, IEnumerable<ClassProfileDto>>
{
    private readonly ISharedLessonDbContext _context;
    private readonly IMapper _mapper;

    public GetClassProfileListDependingOnCountryCommandHandler(ISharedLessonDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<IEnumerable<ClassProfileDto>> Handle(GetClassProfileListDependingOnCountryCommand request,
        CancellationToken cancellationToken)
    {
        var countryId = request.CountryId;

        var classes = _context.Classes.Where(c =>
                c.User.CountryId == countryId)
            .Take(QueryConstants.SearchClassCount)
            .ToList();

        var classProfileDtos = classes.Select(c =>
                _mapper.Map<ClassProfileDto>(c))
            .ToList();

        return Task.FromResult<IEnumerable<ClassProfileDto>>(classProfileDtos);
    }
}