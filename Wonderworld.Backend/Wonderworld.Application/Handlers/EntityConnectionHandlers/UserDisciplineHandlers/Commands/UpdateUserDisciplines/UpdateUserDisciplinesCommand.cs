using MediatR;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplineHandlers.Commands.
    UpdateUserDisciplines;

public class UpdateUserDisciplinesCommand : IRequest
{
    public User User { get; set; }
    public ICollection<Discipline> NewDisciplines { get; set; } = new List<Discipline>();
}