using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Domain.ConnectionEntities;

public class ClassLanguage
{
    public Guid LanguageId { get; set; }
    public Language Language { get; set; }

    public Guid ClassId { get; set; }
    public Class Class { get; set; }
}