using MediatR;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserLanguagesHandlers.Commands.UpdateUserLanguages;

public class UpdateUserLanguagesQuery : IRequest
{
    public Guid UserId { get; set; }
    public IEnumerable<Guid> NewLanguages { get; set; } = new List<Guid>();
}