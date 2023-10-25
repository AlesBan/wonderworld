namespace Wonderworld.Application.Dtos.InvitationDtos;

public class CreateInvitationRequestDto
{
    public Guid ClassSenderId { get; set; }
    public Guid ClassReceiverId { get; set; }
    public string DateOfInvitation { get; set; }
    public string? InvitationText { get; set; } = string.Empty;
}