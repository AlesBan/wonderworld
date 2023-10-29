using Wonderworld.Application.Interfaces.Exceptions;

namespace Wonderworld.Application.Common.Exceptions.Database;

public class UserPropertyNotFoundException : Exception, IDbException
{
    public UserPropertyNotFoundException(Guid userId, string propertyName) :
        base("User property " + propertyName + " with " + userId + "id was not found.")
    {
    }
}