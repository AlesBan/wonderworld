using System.Globalization;

namespace Wonderworld.Infrastructure.Constants;

public static class EmailConstants
{
    public const string EmailConfirmationSubject = "HiClass Confirmation";

    public const string EmailConfirmationMessage = "Thank you for joining our class! We are glad to have you on board. " +
                                                   "Enter this code on the website page to confirm your email address." +
                                                   "If you didn't sign up, please ignore this message.\n\n";

    public const string EmailInvitationSubject = "HiClass Invitation";

    public static string GetEmailSenderInvitationMessage(string emailReceiver, DateTime invitationTime)
    {
        return $"You've sent a call invitation to a user with {emailReceiver} email.\n" +
               $"Time of invitation: {invitationTime.ToString(CultureInfo.InvariantCulture)}";
    }
    
    public static string GetEmailReceiverInvitationMessage(string emailSender, DateTime invitationTime)
    {
        return $"You've been sent a call invitation by a user with {emailSender} email.\n" +
               $"Time of invitation: {invitationTime.ToString(CultureInfo.InvariantCulture)}";
    }
    
    public const string EmailResetPasswordSubject = "HiClass Reset Password";
    
    public const string EmailResetPasswordMessage = "You've requested to reset your password.\n" +
                                                   "Enter this code on the website page to reset your password." +
                                                   "If you didn't sign up, please ignore this message.\n\n";
}