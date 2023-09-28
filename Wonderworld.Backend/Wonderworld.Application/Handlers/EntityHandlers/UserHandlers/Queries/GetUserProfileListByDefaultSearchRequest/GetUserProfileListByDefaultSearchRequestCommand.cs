using MediatR;
using Wonderworld.Application.Dtos.ProfileDtos;
using Wonderworld.Application.Dtos.SearchDtos;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListByDefaultSearchRequest;

public class GetUserProfileListByDefaultSearchRequestCommand : IRequest<IEnumerable<UserProfileDto>>
{
    public DefaultSearchRequestDto SearchRequest { get; set; }
}