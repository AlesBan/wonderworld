using System.ComponentModel.DataAnnotations;
using Wonderworld.Application.Common.Exceptions.Class;
using Wonderworld.Application.Common.Exceptions.Invitation;

namespace Wonderworld.Application.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class NotEqualAttribute : ValidationAttribute
{
    private readonly string _otherProperty;
    private readonly string _propertyName;

    public NotEqualAttribute(string otherProperty, string propertyName)
    {
        _otherProperty = otherProperty;
        _propertyName = propertyName;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var otherPropertyInfo = validationContext.ObjectType
            .GetProperty(_otherProperty);

        if (otherPropertyInfo == null)
            throw new EqualityInvitationPropertyException(_propertyName);
        
        var otherPropertyValue = otherPropertyInfo.GetValue(validationContext
            .ObjectInstance);
        
        if (otherPropertyValue == null)
            throw new EqualityInvitationPropertyException(_propertyName);

        return (Equals(value, otherPropertyValue) ? throw new EqualityInvitationPropertyException(_propertyName): ValidationResult.Success) ?? throw new InvalidOperationException();
    }
}