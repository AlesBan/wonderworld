using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Queries.GetClass;

public class GetClassByIdQuery : IRequest<Class>
{
    public Guid ClassId { get; set; }

    public GetClassByIdQuery(Guid classId)
    {
        ClassId = classId;
    }
}