using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Domain.ConnectionEntities;

public class UserRole
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public Guid RoleId { get; set; }
    public Role Role { get; set; }
    
}