using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Wonderworld.API.Helpers.JwtHelpers;
using Wonderworld.API.Models;
using Wonderworld.Application.Common.Exceptions.Authentication;
using Wonderworld.Application.Common.Exceptions.User;
using Wonderworld.Application.Common.Exceptions.User.Forbidden;

namespace Wonderworld.API.Filters;

public class CheckUserCreateAccountAbilityAttribute : TypeFilterAttribute
{
    public CheckUserCreateAccountAbilityAttribute() : base(typeof(CheckUserCreateAccountAbilityImplementation))
    {
    }

    private class CheckUserCreateAccountAbilityImplementation : IAsyncActionFilter
    {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var isCreateAccount = JwtHelper.GetIsCreatedAccountFromClaims(context.HttpContext);

            if (!isCreateAccount)
            {
                return next();
            }

            var userId = JwtHelper.GetUserIdFromClaims(context.HttpContext);
            throw new UserAlreadyHasAccountException(userId);
        }
    }
}