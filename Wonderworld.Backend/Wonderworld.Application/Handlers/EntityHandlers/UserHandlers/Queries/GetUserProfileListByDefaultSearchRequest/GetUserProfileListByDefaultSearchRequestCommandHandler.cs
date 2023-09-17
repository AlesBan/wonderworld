using AutoMapper;
using MediatR;
using Wonderworld.Application.Dtos.ProfileDtos;
using Wonderworld.Application.Interfaces;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListByDefaultSearchRequest;

public class GetUserProfileListByDefaultSearchRequestCommandHandler : IRequestHandler<
    GetUserProfileListByDefaultSearchRequestCommand, IEnumerable<UserProfileDto>>
{
    private readonly ISharedLessonDbContext _context;
    private readonly IMapper _mapper;

    public GetUserProfileListByDefaultSearchRequestCommandHandler(IMapper mapper, ISharedLessonDbContext context)
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

        var users = _context.Users.Where(u => u.Country == country &&
                                              disciplines.Any(d =>
                                                  u.UserDisciplines.Any(ud =>
                                                      ud.Discipline.DisciplineId == d.DisciplineId)))
            .ToList();

        var userProfileDtos = users.Select(u =>
                _mapper.Map<UserProfileDto>(u))
            .ToList();

        return Task.FromResult<IEnumerable<UserProfileDto>>(userProfileDtos);
    }
}