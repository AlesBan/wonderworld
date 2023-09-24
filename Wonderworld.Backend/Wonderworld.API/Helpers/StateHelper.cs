using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Wonderworld.API.Constants;
using Wonderworld.API.Models.Authentication;

namespace Wonderworld.API.Helpers;

public static class StateHelper
{
    public static IActionResult CheckModelState(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid)
        {
            return new BadRequestObjectResult(new AuthResult()
            {
                Result = false,
                Errors = new List<string>()
                {
                    AuthConstants.InvalidPayloadErrorMessage
                }
            });
        }

        return new OkObjectResult(new AuthResult());
    }
}
