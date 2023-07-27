using MediatR;

namespace Wonderworld.Application.Handlers.UserHandlers.Commands.UpdateUserPosition;

public class UpdateUserPositionCommand : IRequest
{
    public Guid UserId { get; set; }
    public bool IsATeacher { get; set; }
    public bool IsAnExpert { get; set; }
    
}