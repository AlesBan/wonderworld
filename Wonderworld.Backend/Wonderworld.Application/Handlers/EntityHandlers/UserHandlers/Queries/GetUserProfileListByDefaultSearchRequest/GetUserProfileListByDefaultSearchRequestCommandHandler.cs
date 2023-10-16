using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Dtos.ClassDtos;
using Wonderworld.Application.Dtos.InstitutionDtos;
using Wonderworld.Application.Dtos.UserDtos;
using Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Queries.GetClasses;
using Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplinesByIds;
using Wonderworld.Application.Handlers.EntityHandlers.LanguageHandlers.Queries.GetLanguagesByIds;
using Wonderworld.Application.Interfaces;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListByDefaultSearchRequest;

public class GetUserProfileListByDefaultSearchRequestCommandHandler : IRequestHandler<
    GetUserProfileListByDefaultSearchRequestCommand, IEnumerable<UserProfileDto>>
{
    private readonly ISharedLessonDbContext _context;
    private readonly IMapper _mapper;

    public GetUserProfileListByDefaultSearchRequestCommandHandler(ISharedLessonDbContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IEnumerable<UserProfileDto>> Handle(GetUserProfileListByDefaultSearchRequestCommand request,
        CancellationToken cancellationToken)
    {
        var searchRequest = request.SearchRequest;
        var country = searchRequest.Country;
        var disciplines = searchRequest.Disciplines;

        var userDisciplineIds = disciplines.Select(d =>
            d.DisciplineId).ToList();

        var users = _context.Users
            .Include(u => u.Country)
            .Include(u => u.City)
            .Include(u => u.Classes)
            .Include(u => u.Institution)
            .Include(u => u.UserDisciplines)
            .ThenInclude(ud => ud.Discipline)
            .Where(u => u.Country != null && u.Country == country)
            .ToList()
            .Where(u => u.UserDisciplines.Any(ud =>
                userDisciplineIds.Contains(ud.Discipline.DisciplineId)))
            .ToList();

        await Task.Delay(20);

        var userProfileDtos = users.Select(u =>
                _mapper.Map<UserProfileDto>(u))
            .ToList();


        return await Task.FromResult<IEnumerable<UserProfileDto>>(userProfileDtos);
    }
}