using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Domain.EntityConnections;

public class UserGrade
{
    public Guid GradeId { get; set; }
    public Grade Grade { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    
}