using MediatR;
using Wonderworld.Application.Dtos.SearchDtos;
using Wonderworld.Application.Dtos.UserDtos;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListBySearchRequest;

public class GetUserProfileListBySearchRequestCommand : IRequest<IEnumerable<UserProfileDto>>
{
    public SearchRequestDto SearchRequest { get; set; }
}