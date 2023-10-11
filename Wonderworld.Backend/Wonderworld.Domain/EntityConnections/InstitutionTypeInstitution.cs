using Wonderworld.Domain.Entities.Job;

namespace Wonderworld.Domain.EntityConnections;

public class InstitutionTypeInstitution
{
    public Guid InstitutionTypeId { get; set; }
    public InstitutionType InstitutionType { get; set; }
    
    public Guid InstitutionId { get; set; }
    public Institution Institution { get; set; }
}
