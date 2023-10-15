using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Queries.GetClasses;

public class GetClassesCommand : IRequest<IEnumerable<Class>>
{
    public Guid UserId { get; set; }
    public IEnumerable<Guid> ClassIds { get; set; } = new List<Guid>();

    public GetClassesCommand(Guid userId, IEnumerable<Guid> classIds)
    {
        UserId = userId;
        ClassIds = classIds;
    }
}