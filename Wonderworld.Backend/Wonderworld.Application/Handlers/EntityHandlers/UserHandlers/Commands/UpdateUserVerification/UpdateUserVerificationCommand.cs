using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserVerification;

public class UpdateUserVerificationCommand : IRequest<User>
{
    public Guid UserId { get; set; }
    public string VerificationCode { get; set; }
}