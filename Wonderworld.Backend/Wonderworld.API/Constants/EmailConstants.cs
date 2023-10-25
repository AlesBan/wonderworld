namespace Wonderworld.API.Constants;

public static class EmailConstants
{
    public const string EmailConfirmationSubject = "HiClass Confirmation";

    public const string EmailConfirmationMessage =
        @"Click this link to verify your email: http://localhost:7280/api/user/verify-email?token=";

    public const string EmailInvitationSubject = "HiClass Invitation";

    public static string GetEmailSenderInvitationMessage(string emailReceiver, DateTime invitationTime)
    {
        return $"You've sent a call invitation to a user with {emailReceiver} email.\n" +
               $"Time of invitation: {invitationTime}";
    }

    public static string GetEmailReceiverInvitationMessage(string emailSender, DateTime invitationTime)
    {
        return $"You've been sent a call invitation by a user with {emailSender} email.\n" +
               $"Time of invitation: {invitationTime}";
    }
}