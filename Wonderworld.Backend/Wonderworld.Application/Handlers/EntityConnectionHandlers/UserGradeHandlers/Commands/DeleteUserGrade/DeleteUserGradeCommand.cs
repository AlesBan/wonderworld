using MediatR;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserGradeHandlers.Commands.DeleteUserGrade;

public class DeleteUserGradeCommand : IRequest
{
    public User User { get; set; }
    public Grade Grade { get; set; }
}