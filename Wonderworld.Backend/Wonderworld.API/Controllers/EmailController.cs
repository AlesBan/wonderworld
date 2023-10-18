using Microsoft.AspNetCore.Mvc;
using Wonderworld.Infrastructure.Services.EmailHandlerService;

namespace Wonderworld.API.Controllers;

public class EmailController : BaseController
{
    private readonly IEmailHandlerService _emailHandlerService;
    private readonly IConfiguration _configuration;

    public EmailController(IEmailHandlerService emailHandlerService, IConfiguration configuration)
    {
        _emailHandlerService = emailHandlerService;
        _configuration = configuration;
    }

    [HttpPost("send-email")]
    public async Task<IActionResult> SendEmail()
    {
        await _emailHandlerService.SendAsync(_configuration, "alesban36@gmail.com", "Wonderworld", "Welcome to Wonderworld!");
        return Ok();
    }
}