using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Domain.ConnectionEntities;

public class UserDiscipline
{
    public Guid DisciplineId { get; set; }
    public Discipline Discipline { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
}