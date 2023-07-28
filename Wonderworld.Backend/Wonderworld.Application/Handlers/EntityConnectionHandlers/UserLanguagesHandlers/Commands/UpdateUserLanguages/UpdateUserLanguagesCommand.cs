using MediatR;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserLanguagesHandlers.Commands.UpdateUserLanguages;

public class UpdateUserLanguagesCommand : IRequest
{
    public User User { get; set; }
    public ICollection<Language> NewLanguages { get; set; } = new List<Language>();
}