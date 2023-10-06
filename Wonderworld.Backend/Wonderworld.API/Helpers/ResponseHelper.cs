using Microsoft.AspNetCore.Mvc;
using Wonderworld.API.Models;
using Wonderworld.API.Models.Authentication;

namespace Wonderworld.API.Helpers;

public static class ResponseHelper
{
    public static BadRequestObjectResult GetBadRequest(string message)
    {
        return new BadRequestObjectResult(new ResponseResult
        {
            Result = false,
            Errors = new List<string> { message }
        });
    }

    public static BadRequestObjectResult GetAuthBadRequest(string message)
    {
        return new BadRequestObjectResult(new AuthResult
        {
            Result = false,
            Errors = new List<string> { message }
        });
    }

    public static OkObjectResult GetAuthResultOk(string token)
    {
        return new OkObjectResult(new AuthResult
        {
            Result = true,
            Token = token
        });
    }
}