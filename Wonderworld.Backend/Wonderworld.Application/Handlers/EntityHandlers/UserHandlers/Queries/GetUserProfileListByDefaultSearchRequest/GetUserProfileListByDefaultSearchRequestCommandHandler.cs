using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Dtos.UserDtos;
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

    public Task<IEnumerable<UserProfileDto>> Handle(GetUserProfileListByDefaultSearchRequestCommand request,
        CancellationToken cancellationToken)
    {
        var searchRequest = request.SearchRequest;
        var country = searchRequest.Country;
        var disciplines = searchRequest.Disciplines;

        var userDisciplineIds = disciplines.Select(d => 
            d.DisciplineId).ToList();

        var users = _context.Users
            .Include(u => u.UserDisciplines)
            .ThenInclude(ud => ud.Discipline)
            .Where(u => u.Country != null && u.Country == country)
            .ToList()
            .Where(u => u.UserDisciplines.Any(ud =>
                userDisciplineIds.Contains(ud.Discipline.DisciplineId)))
            .ToList();

        var userProfileDtos = users.Select(u =>
                _mapper.Map<UserProfileDto>(u))
            .ToList();

        return Task.FromResult<IEnumerable<UserProfileDto>>(userProfileDtos);
    }
}