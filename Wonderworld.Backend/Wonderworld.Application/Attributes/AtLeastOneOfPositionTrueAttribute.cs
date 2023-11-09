using System.ComponentModel.DataAnnotations;
using Wonderworld.Application.Common.Exceptions.User.CreateAccount;

namespace Wonderworld.Application.Attributes;

public class AtLeastOneOfPositionTrueAttribute : ValidationAttribute
{
    private readonly string[] _propertyNames;

    public AtLeastOneOfPositionTrueAttribute(params string[] propertyNames)
    {
        _propertyNames = propertyNames;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var type = validationContext.ObjectType;
        var properties = type.GetProperties();

        var atLeastOneTrue = properties.Any(property =>
            _propertyNames.Contains(property.Name) &&
            property.PropertyType == typeof(bool) &&
            (bool)(property.GetValue(validationContext.ObjectInstance) ?? false));

        if (atLeastOneTrue)
        {
            return ValidationResult.Success;
        }

        throw new AtLeastOfPositionShouldBeTrueException();
    }
}