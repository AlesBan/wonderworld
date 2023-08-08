using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserPosition;

public class UpdateUserPositionCommand : IRequest
{
    public User User { get; set; }
    public bool IsATeacher { get; set; }
    public bool IsAnExpert { get; set; }
    
}