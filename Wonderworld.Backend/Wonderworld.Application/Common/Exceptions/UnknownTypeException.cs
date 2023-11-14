using Wonderworld.Application.Interfaces.Exceptions;

namespace Wonderworld.Application.Common.Exceptions;

public class UnknownTypeException : Exception, IServerException
{
    public UnknownTypeException() : base("Unknown type.")
    {
        
    }
}