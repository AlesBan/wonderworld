using AutoMapper;
using MediatR;
using Wonderworld.Application.Dtos;
using Wonderworld.Application.Dtos.UserDtos;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetProfileUser;

public class GetUserProfileCommandHandler : IRequestHandler<GetUserProfileCommand, UserProfileDto>
{
    private readonly IMapper _mapper;

    public GetUserProfileCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<UserProfileDto> Handle(GetUserProfileCommand request, CancellationToken cancellationToken)
    {
        var userProfile = _mapper.Map<UserProfileDto>(request.User);
        return userProfile;
    }
}