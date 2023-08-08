using MediatR;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserLanguagesHandlers.Commands.DeleteUserLanguages;

public class DeleteUserLanguageCommand : IRequest
{
    public User User { get; set; }
    public Language Language { get; set; }
}