using MediatR;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserGradeHandlers.Commands.CreateUserGrade;

public class CreateUserGradeCommand : IRequest
{
    public User User { get; set; }
    public Grade Grade { get; set; }
}