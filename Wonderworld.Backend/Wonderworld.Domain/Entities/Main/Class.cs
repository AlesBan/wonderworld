using Wonderworld.Domain.ConnectionEntities;

namespace Wonderworld.Domain.Entities.Main;

public class Class
{
    public Guid ClassId { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
    public int ClassNumber { get; set; }
    public int ClassAge { get; set; }


    public ICollection<ClassLanguage> ClassLanguages { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime DeletedAt { get; set; }

    public ICollection<ClassDiscipline> ClassDisciplines { get; set; }
}