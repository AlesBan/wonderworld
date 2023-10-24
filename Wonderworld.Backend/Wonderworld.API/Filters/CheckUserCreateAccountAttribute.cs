using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Wonderworld.API.Helpers.JwtHelpers;
using Wonderworld.API.Models;
using Wonderworld.Application.Common.Exceptions.Authentication;
using Wonderworld.Application.Common.Exceptions.User.Forbidden;

namespace Wonderworld.API.Filters;

public class CheckUserCreateAccountAttribute : TypeFilterAttribute
{
    public CheckUserCreateAccountAttribute() : base(typeof(CheckUserCreateAccountImplementation))
    {
    }

    private class CheckUserCreateAccountImplementation : IAsyncActionFilter
    {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var isCreateAccount = JwtHelper.GetIsCreatedAccountFromClaims(context.HttpContext);

            if (isCreateAccount)
            {
                return next();
            }

            var userId = JwtHelper.GetUserIdFromClaims(context.HttpContext);
            throw new UserHasNotAccountException(userId);
        }
    }
}