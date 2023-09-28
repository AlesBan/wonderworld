using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Domain.Entities.Main;

public class Role
{
    public Guid RoleId { get; set; }
    public string Title { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
}