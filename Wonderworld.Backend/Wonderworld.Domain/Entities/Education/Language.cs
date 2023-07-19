using Wonderworld.Domain.ConnectionEntities;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Domain.Entities.Education;

public class Language
{
    public Guid LanguageId { get; set; }
    
    public string Title { get; set; }
    
    public ICollection<TeacherLanguage> TeacherLanguages { get; set; }
    public ICollection<ClassLanguage> ClassLanguages { get; set; }
    
}