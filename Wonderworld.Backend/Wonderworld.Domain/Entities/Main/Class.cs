using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Domain.Entities.Main;

public class Class
{
    public Guid ClassId { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid GradeId { get; set; }
    public Grade Grade { get; set; }

    public ICollection<ClassLanguage> ClassLanguages { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime DeletedAt { get; set; }

    public ICollection<ClassDiscipline> ClassDisciplines { get; set; }
}