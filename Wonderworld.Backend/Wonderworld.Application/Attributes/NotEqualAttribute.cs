using System.ComponentModel.DataAnnotations;
using Wonderworld.Application.Common.Exceptions.Dtos;

namespace Wonderworld.Application.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class NotEqualAttribute : ValidationAttribute
{
    private readonly string _otherProperty;

    public NotEqualAttribute(string otherProperty)
    {
        _otherProperty = otherProperty;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var otherPropertyInfo = validationContext.ObjectType
            .GetProperty(_otherProperty);

        if (otherPropertyInfo == null)
            throw new InvalidClassIdsException();
        
        var otherPropertyValue = otherPropertyInfo.GetValue(validationContext
            .ObjectInstance);
        
        if (otherPropertyValue == null)
            throw new InvalidClassIdsException();

        return (Equals(value, otherPropertyValue) ? throw new InvalidClassIdsException(): ValidationResult.Success) ?? throw new InvalidOperationException();
    }
}