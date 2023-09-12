using MediatR;
using Wonderworld.Application.Dtos.ProfileDtos;
using Wonderworld.Domain.Entities.Education;

namespace Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Queries.
    GetClassProfileListDependingOnDisciplines;

public class GetClassProfileListDependingOnDisciplinesCommand : IRequest<IEnumerable<ClassProfileDto>>
{
    public List<Discipline> Disciplines { get; set; }
}