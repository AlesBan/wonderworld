using Wonderworld.Application.Interfaces.Exceptions;

namespace Wonderworld.Application.Common.Exceptions.Invitation;

public class EqualityInvitationPropertyException : Exception, IUiException
{
    public EqualityInvitationPropertyException(string propertyName) :
        base(GetErrorMessage(propertyName))
    {
    }

    private static string GetErrorMessage(string propertyName)
    {
        var isClassProperty = IsPropertyOfClass(propertyName);
        var isUserProperty = IsPropertyOfUser(propertyName);

        if (isClassProperty)
        {
            return "ClassSenderId and ClassReceiverId must not be the same.";
        }

        if (isUserProperty)
        {
            return "UserSenderId and UserReceiverId must not be the same.";
        }

        return "Invalid property name.";
    }

    private static bool IsPropertyOfClass(string propertyName)
    {
        var classType = typeof(Domain.Entities.Main.Class);
        var property = classType.GetProperty(propertyName);

        return property != null;
    }

    private static bool IsPropertyOfUser(string propertyName)
    {
        var userType = typeof(Domain.Entities.Main.User);
        var property = userType.GetProperty(propertyName);

        return property != null;
    }
}