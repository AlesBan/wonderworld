namespace Wonderworld.Application.Common.Exceptions.Class;

public class InvalidClassReceiverException : Exception
{
    public InvalidClassReceiverException() : base("ClassReceiver can't be user's class")
    {
    }
}