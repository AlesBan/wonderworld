using Microsoft.AspNetCore.Mvc;
using Wonderworld.API.Models;
using Wonderworld.API.Models.Authentication;
using Wonderworld.Application.Dtos.ClassDtos;

namespace Wonderworld.API.Helpers;

public static class ResponseHelper
{
    public static IActionResult GetBadRequest(string message)
    {
        return new BadRequestObjectResult(new ResponseResult
        {
            Result = false,
            Errors = new List<string> { message },
        });
    }

    public static OkObjectResult GetOkResult()
    {
        return new OkObjectResult(new ResponseResult
        {
            Result = true,
            Value = null
        });
    }

    public static OkObjectResult GetOkResult(object value)
    {
        return new OkObjectResult(new ResponseResult
        {
            Result = true,
            Value = value
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