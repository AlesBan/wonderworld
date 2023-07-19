using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Domain.ConnectionEntities;

public class ClassDiscipline
{
    public Guid DisciplineId { get; set; }
    public Discipline Discipline { get; set; }
    
    public Guid ClassId { get; set; }
    public Class Class { get; set; }
}