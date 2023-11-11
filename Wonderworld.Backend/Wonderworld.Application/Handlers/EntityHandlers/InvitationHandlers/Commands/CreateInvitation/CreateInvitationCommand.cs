using System.ComponentModel.DataAnnotations;
using MediatR;
using Wonderworld.Application.Attributes;
using Wonderworld.Domain.Entities.Communication;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.InvitationHandlers.Commands.CreateInvitation;

public class CreateInvitationCommand : IRequest<Invitation>
{
    [Required]
    [NotEqual(nameof(UserReceiverId), nameof(User))]
    public Guid UserSenderId { get; set; }

    [Required] public Guid UserReceiverId { get; set; }

    [Required]
    [NotEqual(nameof(ClassReceiverId), nameof(Class))]
    public Guid ClassSenderId { get; set; }

    [Required] public Guid ClassReceiverId { get; set; }
    [Required] public DateTime DateOfInvitation { get; set; }
    [Required] public string Status { get; set; }
    [Required] public string? InvitationText { get; set; }
}