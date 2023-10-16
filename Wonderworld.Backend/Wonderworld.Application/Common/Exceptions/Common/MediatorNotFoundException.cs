using Wonderworld.Application.Interfaces.Exceptions;

namespace Wonderworld.Application.Common.Exceptions.Common;

public class MediatorNotFoundException : Exception, IServerException
{
    public MediatorNotFoundException() : base("IMediator service not found in the dependency injection container.")
    {
    }
}