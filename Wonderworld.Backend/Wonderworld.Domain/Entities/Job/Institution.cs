using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Domain.Entities.Job;

public class Institution
{
    public Guid InstitutionId { get; set; }
    public string Title { get; set; }= string.Empty;
    public string Address { get; set; } = string.Empty;
    public ICollection<User> Users { get; set; } = new List<User>();
    public List<InstitutionTypeInstitution> InstitutionTypes { get; set; } = new List<InstitutionTypeInstitution>();

}