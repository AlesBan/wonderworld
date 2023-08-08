using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Domain.EntityConnections;

public class UserLanguage
{
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid LanguageId { get; set; }
    public Language Language { get; set; }
}