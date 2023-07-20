using Wonderworld.Domain.ConnectionEntities;

namespace Wonderworld.Domain.Entities.Education;

public class Discipline
{
    public Guid DisciplineId { get; set; }
    public string Title { get; set; }
    
    public ICollection<ClassDiscipline> ClassDisciplines { get; set; }
    public ICollection<UserDiscipline> TeacherDisciplines { get; set; }
    
}