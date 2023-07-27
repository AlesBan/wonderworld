namespace Wonderworld.Application.Common.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string entityName, object key) :
        base($"Entity \"{entityName}\" ({key}) was not found.")
    {
    }

    public NotFoundException(string entityName, object connectionId1, object connectionId2) :
        base($"EntityConnection \"{entityName}\" " +
             $"(First entityId: {connectionId1}, " +
             $"Second entityId: {connectionId2}) was not found.")
    {
    }
}