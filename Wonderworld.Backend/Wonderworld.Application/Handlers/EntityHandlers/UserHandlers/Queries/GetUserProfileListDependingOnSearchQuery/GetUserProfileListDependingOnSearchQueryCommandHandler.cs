using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Dtos.ProfileDtos;
using Wonderworld.Application.Interfaces;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListDependingOnSearchQuery;

public class GetUserProfileListDependingOnSearchQueryCommandHandler : IRequestHandler<
    GetUserProfileListDependingOnSearchQueryCommand, IEnumerable<UserProfileDto>>
{
    private readonly ISharedLessonDbContext _context;
    private readonly IMapper _mapper;

    public GetUserProfileListDependingOnSearchQueryCommandHandler(ISharedLessonDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<IEnumerable<UserProfileDto>> Handle(GetUserProfileListDependingOnSearchQueryCommand request,
        CancellationToken cancellationToken)
    {
        var searchRequest = request.SearchRequest;
        var countryTitles = searchRequest.Countries;
        var gradeNumbers = searchRequest.Grades;
        var disciplineTitles = searchRequest.Disciplines;
        var languageTitles = searchRequest.Languages;

        var users = _context.Users
            .Include(u => u.Country)
            .Include(u => u.UserGrades).ThenInclude(ug => ug.Grade)
            .Include(u => u.UserDisciplines).ThenInclude(d => d.Discipline)
            .Include(u => u.UserLanguages).ThenInclude(l => l.Language)
            .Where(u =>
                u.Country != null && countryTitles.Contains(u.Country.Title) &&
                u.UserGrades.Any(ug => gradeNumbers.Contains(ug.Grade.GradeNumber.ToString())) &&
                u.UserDisciplines.Any(d => disciplineTitles.Contains(d.Discipline.Title)) &&
                u.UserLanguages.Any(l => languageTitles.Contains(l.Language.Title)));

        var userProfileDtos = users.Select(u =>
                _mapper.Map<UserProfileDto>(u))
            .ToList();

        return Task.FromResult<IEnumerable<UserProfileDto>>(userProfileDtos);
    }
}