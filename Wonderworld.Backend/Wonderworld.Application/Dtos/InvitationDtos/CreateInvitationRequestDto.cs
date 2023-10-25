namespace Wonderworld.Application.Dtos.InvitationDtos;

public class CreateInvitationRequestDto
{
    public Guid ClassSenderId { get; set; }
    public Guid ClassReceiverId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime DateOfInvitation { get; set; }
    public string? InvitationText { get; set; } = string.Empty;
}