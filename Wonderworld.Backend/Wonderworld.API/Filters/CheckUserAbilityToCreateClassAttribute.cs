using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Wonderworld.API.Helpers.JwtHelpers;
using Wonderworld.Application.Common.Exceptions.User;

namespace Wonderworld.API.Filters;

public class CheckUserAbilityToCreateClassAttribute : TypeFilterAttribute
{
    public CheckUserAbilityToCreateClassAttribute() : base(typeof(CheckUserAbilityToCreateClassImplementation))
    {
    }
}

public class CheckUserAbilityToCreateClassImplementation : IAsyncActionFilter
{
    public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var positionInfo = JwtHelper.GetPositionInfoFromClaims(context.HttpContext);
        
        if (!positionInfo.IsTeacher)
        {
            throw new UserUnableToCreateClassException();
        }
        
        return next();
    }
}