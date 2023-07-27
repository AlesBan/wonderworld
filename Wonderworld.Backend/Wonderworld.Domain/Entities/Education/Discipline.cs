using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Domain.Entities.Education;

public class Discipline
{
    public Guid DisciplineId { get; set; }
    public string Title { get; set; }
    
    public ICollection<ClassDiscipline> ClassDisciplines { get; set; }
    public ICollection<UserDiscipline> UserDisciplines { get; set; }
    
}