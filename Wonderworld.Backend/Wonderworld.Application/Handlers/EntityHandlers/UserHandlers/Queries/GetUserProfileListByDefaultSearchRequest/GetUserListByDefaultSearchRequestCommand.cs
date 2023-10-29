using MediatR;
using Wonderworld.Application.Dtos.SearchDtos;
using Wonderworld.Application.Dtos.UserDtos;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListByDefaultSearchRequest;

public class GetUserListByDefaultSearchRequestCommand : IRequest<IEnumerable<User>>
{
    public DefaultSearchRequestDto SearchRequest { get; set; }
}