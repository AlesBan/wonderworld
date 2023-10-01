using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wonderworld.API.Filters;
using Wonderworld.Application.Common.Exceptions;

namespace Wonderworld.API.Controllers;

[Route("api/[controller]")]
[ValidateModelStateFilter]
[ApiController]
public class BaseController : ControllerBase
{
    protected IMediator Mediator =>
        HttpContext.RequestServices.GetService<IMediator>() ?? throw new MediatorNotFoundException();

    internal Guid UserId => User.Identity is { IsAuthenticated: true }
        ? Guid.Empty
        : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
}