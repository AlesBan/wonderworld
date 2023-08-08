using Wonderworld.Domain.Entities.Main;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Domain.Entities.Education;

public class Grade
{
    public Guid GradeId { get; set; }
    public int GradeNumber { get; set; }
    public ICollection<Class> Classes { get; set; } = new List<Class>();
    public ICollection<UserGrade> UserGrades { get; set; } = new List<UserGrade>();
}