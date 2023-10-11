using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wonderworld.API.Filters;
using Wonderworld.API.Helpers.JwtHelpers;
using Wonderworld.Application.Common.Exceptions;

namespace Wonderworld.API.Controllers;

[Route("api/[controller]")]
// [ValidateModelStateFilter]
[ApiController]
public class BaseController : ControllerBase
{
    protected Guid UserId => JwtHelper.GetUserIdFromClaims(HttpContext);
    protected IMediator Mediator =>
        HttpContext.RequestServices.GetService<IMediator>() ?? throw new MediatorNotFoundException();
}