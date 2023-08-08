using MediatR;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplineHandlers.Commands.CreateUserDisciplines;

public class CreateUserDisciplineCommand : IRequest
{
    public User User { get; set; }
    public Discipline Discipline { get; set; }
}