using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Commands.DeleteClass;

public class DeleteClassCommand : IRequest
{
    public Guid ClassId { get; set; }

    public DeleteClassCommand(Guid classId)
    {
        ClassId = classId;
    }
}