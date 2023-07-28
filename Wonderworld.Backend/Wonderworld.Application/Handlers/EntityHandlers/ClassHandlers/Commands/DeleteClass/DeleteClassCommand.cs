using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Commands.DeleteClass;

public class DeleteClassCommand : IRequest
{
    public Class Class { get; set; }
}