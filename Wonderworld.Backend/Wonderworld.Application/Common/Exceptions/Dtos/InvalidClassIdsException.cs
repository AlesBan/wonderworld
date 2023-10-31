using Wonderworld.Application.Interfaces.Exceptions;

namespace Wonderworld.Application.Common.Exceptions.Dtos;

public class InvalidClassIdsException : Exception, IUiException
{
    public InvalidClassIdsException() : base("ClassSenderId and ClassReceiverId must not be the same.")
    {
        
    }
}