using MediatR;
using Wonderworld.Application.Dtos.ProfileDtos;
using Wonderworld.Application.Dtos.SearchDtos;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListBySearchRequest;

public class GetUserProfileListBySearchRequestCommand : IRequest<IEnumerable<UserProfileDto>>
{
    public SearchRequestDto SearchRequest { get; set; }
}