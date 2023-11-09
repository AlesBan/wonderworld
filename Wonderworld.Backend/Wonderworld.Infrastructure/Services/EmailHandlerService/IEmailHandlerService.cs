using Microsoft.Extensions.Configuration;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Infrastructure.Services.EmailHandlerService;

public interface IEmailHandlerService
{
    public Task SendVerificationEmail(User user, string verificationCode);
    public Task SendAsync(IConfiguration configuration, string emailReceiver, string subject, string message);
}