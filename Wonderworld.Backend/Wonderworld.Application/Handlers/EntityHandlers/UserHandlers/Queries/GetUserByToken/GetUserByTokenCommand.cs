using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserByToken;

public class GetUserByTokenCommand : IRequest<User>
{
    public string Token { get; set; }
    public GetUserByTokenCommand(string token)
    {
        Token = token;
    }
}