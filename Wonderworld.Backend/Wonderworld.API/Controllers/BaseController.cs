using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wonderworld.Application.Common.Exceptions;

namespace Wonderworld.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected IMediator Mediator => HttpContext.RequestServices.GetService<IMediator>() ?? throw new MediatorNotFoundException();
    
    internal Guid UserId => User.Identity is { IsAuthenticated: true } ? 
        Guid.Empty : 
        Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
}