using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Wonderworld.API.Helpers.JwtHelpers;
using Wonderworld.Application.Common.Exceptions.User.Forbidden;

namespace Wonderworld.API.Filters;

public class CheckUserVerificationAttribute : TypeFilterAttribute
{
    public CheckUserVerificationAttribute() : base(typeof(CheckUserVerificationAttributeImplementation))
    {
    }

    private class CheckUserVerificationAttributeImplementation : IAsyncActionFilter
    {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var isVerified = JwtHelper.GetIsVerifiedFromClaims(context.HttpContext);

            if (isVerified)
            {
                return next();
            }

            context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
            
            var userId = JwtHelper.GetUserIdFromClaims(context.HttpContext);
            throw new UserNotVerifiedException(userId);
        }
    }
}