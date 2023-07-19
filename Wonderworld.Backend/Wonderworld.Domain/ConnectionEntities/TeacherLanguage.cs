using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Domain.ConnectionEntities;

public class TeacherLanguage
{
    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; }

    public Guid LanguageId { get; set; }
    public Language Language { get; set; }
}