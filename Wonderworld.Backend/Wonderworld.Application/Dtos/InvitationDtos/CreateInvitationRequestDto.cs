using System.ComponentModel.DataAnnotations;
using Wonderworld.Application.Attributes;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Dtos.InvitationDtos;

public class CreateInvitationRequestDto
{
    [Required]
    [NotEqual(nameof(ClassReceiverId), nameof(Class))]
    public Guid ClassSenderId { get; set; }
    [Required] public Guid ClassReceiverId { get; set; }
    [Required] public string DateOfInvitation { get; set; }
    [Required] public string? InvitationText { get; set; } = string.Empty;
}