namespace Wonderworld.Application.Common.Exceptions;

public class MediatorNotFoundException : Exception
{
    public MediatorNotFoundException() : base("IMediator service not found in the dependency injection container.")
    {
    }
}