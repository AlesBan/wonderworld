using MediatR;
using Wonderworld.Application.Dtos.SearchDtos;
using Wonderworld.Application.Dtos.UserDtos;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListBySearchRequest;

public class GetUserListBySearchRequestCommand : IRequest<IEnumerable<User>>
{
    public SearchRequestDto SearchRequest { get; set; }
}