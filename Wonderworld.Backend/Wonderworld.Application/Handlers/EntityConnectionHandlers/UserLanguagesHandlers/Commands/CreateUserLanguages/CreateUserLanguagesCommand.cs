using MediatR;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserLanguagesHandlers.Commands.CreateUserLanguages;

public class CreateUserLanguagesCommand : IRequest
{
    public Guid UserId { get; set; }
    public IEnumerable<Guid> LanguageIds { get; set; }

}