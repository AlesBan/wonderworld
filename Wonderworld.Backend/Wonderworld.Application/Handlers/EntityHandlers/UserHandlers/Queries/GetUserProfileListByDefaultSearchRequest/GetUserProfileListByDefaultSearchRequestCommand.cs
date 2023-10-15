using MediatR;
using Wonderworld.Application.Dtos.SearchDtos;
using Wonderworld.Application.Dtos.UserDtos;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListByDefaultSearchRequest;

public class GetUserProfileListByDefaultSearchRequestCommand : IRequest<IEnumerable<UserProfileDto>>
{
    public DefaultSearchRequestDto SearchRequest { get; set; }
}