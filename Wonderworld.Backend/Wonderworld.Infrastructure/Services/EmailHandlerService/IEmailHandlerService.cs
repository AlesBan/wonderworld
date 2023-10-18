using Microsoft.Extensions.Configuration;

namespace Wonderworld.Infrastructure.Services.EmailHandlerService;

public interface IEmailHandlerService
{
    Task SendAsync(IConfiguration configuration, string emailReceiver, string subject, string message);
}