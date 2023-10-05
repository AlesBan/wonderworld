using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Domain.Entities.Job;

public class InstitutionType
{
    public Guid InstitutionTypeId { get; set; }
    public string Title { get; set; } = string.Empty;
    public ICollection<InstitutionTypeInstitution> InstitutionTypes { get; set; } 
        = new List<InstitutionTypeInstitution>();
}