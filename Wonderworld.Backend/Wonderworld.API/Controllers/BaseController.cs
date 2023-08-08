using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Wonderworld.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    private IMediator? Mediator => HttpContext.RequestServices.GetService<IMediator>();
    
    internal Guid UserId => User.Identity is { IsAuthenticated: true } ? 
        Guid.Empty : 
        Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
}