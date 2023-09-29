namespace Wonderworld.Application.Common.Exceptions;

public class DeserializationOfYandexResponseException : Exception
{
    public DeserializationOfYandexResponseException()
    {
    }

    public DeserializationOfYandexResponseException(string message) : base(message)
    {
    }
}