using MediatR;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserLanguagesHandlers.Commands.CreateUserLanguages;

public class CreateUserLanguageCommand : IRequest
{
    public User User { get; set; }
    public Language Language { get; set; }
}