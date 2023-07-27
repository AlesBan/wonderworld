using Wonderworld.Domain.Entities.Main;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Domain.Entities.Education;

public class Language
{
    public Guid LanguageId { get; set; }
    
    public string Title { get; set; }
    
    public ICollection<UserLanguage> TeacherLanguages { get; set; }
    public ICollection<ClassLanguage> ClassLanguages { get; set; }
    
}