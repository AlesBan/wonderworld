using Wonderworld.API.Constants;
using Wonderworld.Infrastructure.Services.EmailHandlerService;

namespace Wonderworld.API.Helpers.EmailHelper;

public class EmailHelper : IEmailHelper
{
    private readonly IEmailHandlerService _emailHandlerService;
    private readonly IConfiguration _configuration;

    public EmailHelper(IEmailHandlerService emailHandlerService, IConfiguration configuration)
    {
        _emailHandlerService = emailHandlerService;
        _configuration = configuration;
    }

   
}