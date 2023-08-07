using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Queries.GetClass;

public class GetClassCommand : IRequest<Class>
{
    public Guid ClassId { get; set; }
}