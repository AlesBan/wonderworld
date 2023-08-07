using AutoMapper;
using MediatR;
using Wonderworld.Application.Dtos;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetProfileUser;

public class GetProfileUserCommandHandler : IRequestHandler<GetProfileUserCommand, UserProfileDto>
{
    private readonly IMapper _mapper;
    public GetProfileUserCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<UserProfileDto> Handle(GetProfileUserCommand request, CancellationToken cancellationToken)
    {
        
        var userProfile = _mapper.Map<UserProfileDto>(request.User);
        return userProfile;
    }
}