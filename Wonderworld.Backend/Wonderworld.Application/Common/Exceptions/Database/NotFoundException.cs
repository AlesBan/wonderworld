using Wonderworld.Application.Interfaces.Exceptions;

namespace Wonderworld.Application.Common.Exceptions.Database;

public class NotFoundException : Exception, IDbException
{
    /// <summary>
    /// NotFoundException entity
    /// </summary>
    /// <param name="entityName"></param>
    /// <param name="key"></param>
    public NotFoundException(string entityName, object key) :
        base($"Entity {entityName} ({key}) was not found.")
    {
    }

    /// <summary>
    /// NotFoundException connection
    /// </summary>
    /// <param name="entityName"></param>
    /// <param name="connectionId1"></param>
    /// <param name="connectionId2"></param>
    public NotFoundException(string entityName, object connectionId1, object connectionId2) :
        base($"EntityConnection {entityName} " +
             $"(First entityId: {connectionId1}, " +
             $"Second entityId: {connectionId2}) was not found.")
    {
    }
}