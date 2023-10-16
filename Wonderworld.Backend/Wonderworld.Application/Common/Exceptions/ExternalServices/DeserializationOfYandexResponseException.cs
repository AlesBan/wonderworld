using Wonderworld.Application.Interfaces.Exceptions;

namespace Wonderworld.Application.Common.Exceptions.ExternalServices;

public class DeserializationOfYandexResponseException : Exception, IServerException
{
    public DeserializationOfYandexResponseException()
    {
    }

    public DeserializationOfYandexResponseException(string message) : base(message)
    {
    }
}