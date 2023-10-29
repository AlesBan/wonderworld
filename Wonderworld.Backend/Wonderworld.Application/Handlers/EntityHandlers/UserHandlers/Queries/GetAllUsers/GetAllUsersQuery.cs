using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<List<User>>
{
}