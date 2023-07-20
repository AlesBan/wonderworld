namespace Wonderworld.Application.Common.Exceptions;

public class DbSetNullException : Exception
{
    public DbSetNullException(string name) :
        base($"The {name} DbSet is null.")
    {
    }
}