using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Wonderworld.API.Helpers.JwtHelpers;
using Wonderworld.Application.Common.Exceptions.User.Forbidden;

namespace Wonderworld.API.Filters;

public class CheckUserVerifiedAttribute : TypeFilterAttribute
{
    public CheckUserVerifiedAttribute() : base(typeof(CheckUserVerifiedAttributeImplementation))
    {
    }

    private class CheckUserVerifiedAttributeImplementation : IAsyncActionFilter
    {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var isVerified = JwtHelper.GetIsVerifiedFromClaims(context.HttpContext);

            if (!isVerified)
            {
                var userId = JwtHelper.GetUserIdFromClaims(context.HttpContext);
                throw new UserNotVerifiedException(userId);
            }

            return next();
        }
    }
}