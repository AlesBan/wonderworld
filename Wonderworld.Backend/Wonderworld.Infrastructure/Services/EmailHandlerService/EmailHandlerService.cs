using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Wonderworld.API.Constants;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Infrastructure.Constants;

namespace Wonderworld.Infrastructure.Services.EmailHandlerService;

public class EmailHandlerService : IEmailHandlerService
{
    private readonly IConfiguration _configuration;

    public EmailHandlerService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendVerificationEmail(User user, string verificationCode)
    {
        var message = EmailConstants.EmailConfirmationMessage + verificationCode;
        await SendAsync(_configuration, user.Email,
            EmailConstants.EmailConfirmationSubject,
            message);
    }

    public async Task SendAsync(IConfiguration configuration, string emailReceiver, string subject, string message)
    {
        var email = new MimeMessage();

        var managerEmail = configuration["HiClassManagerEmail:Email"];
        var managerPassword = configuration["HiClassManagerEmail:Password"];

        email.From.Add(MailboxAddress.Parse(managerEmail));
        email.To.Add(MailboxAddress.Parse(emailReceiver));

        email.Subject = subject;
        email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message };

        using var client = new MailKit.Net.Smtp.SmtpClient();
        await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(managerEmail, managerPassword);
        await client.SendAsync(email);
        await client.DisconnectAsync(true);
    }
}