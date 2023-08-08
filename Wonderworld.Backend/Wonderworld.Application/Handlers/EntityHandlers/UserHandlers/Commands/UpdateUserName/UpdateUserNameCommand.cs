using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserName;

public class UpdateUserNameCommand : IRequest
{
    public User User { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}