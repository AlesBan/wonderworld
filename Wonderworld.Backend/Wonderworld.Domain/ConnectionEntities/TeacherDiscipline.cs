using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Domain.ConnectionEntities;

public class TeacherDiscipline
{
    public Guid DisciplineId { get; set; }
    public Discipline Discipline { get; set; }
    
    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; }
}