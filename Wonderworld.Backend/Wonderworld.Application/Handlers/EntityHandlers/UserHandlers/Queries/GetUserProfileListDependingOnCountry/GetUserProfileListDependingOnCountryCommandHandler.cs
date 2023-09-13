using AutoMapper;
using MediatR;
using Wonderworld.Application.Constants;
using Wonderworld.Application.Dtos.ProfileDtos;
using Wonderworld.Application.Interfaces;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListDependingOnCountry;

public class
    GetUserProfileListDependingOnCountryCommandHandler : IRequestHandler<GetUserProfileListDependingOnCountryCommand,
        IEnumerable<UserProfileDto>>
{
    private readonly ISharedLessonDbContext _context;
    private readonly IMapper _mapper;

    public GetUserProfileListDependingOnCountryCommandHandler(ISharedLessonDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserProfileDto>> Handle(GetUserProfileListDependingOnCountryCommand request,
        CancellationToken cancellationToken)
    {
        var countryId = request.CountryId;
        var isATeacher = request.IsATeacher;
        var isAnExpert = request.IsAnExpert;
        var users = _context.Users
            .Where(u => u.CountryId == countryId &&
                        u.IsATeacher == isATeacher &&
                        u.IsAnExpert == isAnExpert)
            .Take(QueryConstants.SearchTeacherExpertCount)
            .ToList();

        var userProfileDtos = users.Select(u =>
                _mapper.Map<UserProfileDto>(u))
            .ToList();

        return await Task.FromResult(userProfileDtos);
    }
}