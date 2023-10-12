using MediatR;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplineHandlers.Commands.DeleteUserDisciplines;

public class DeleteUserDisciplineCommand : IRequest
{
    public User User { get; set; }
    public Discipline Discipline { get; set; }
}