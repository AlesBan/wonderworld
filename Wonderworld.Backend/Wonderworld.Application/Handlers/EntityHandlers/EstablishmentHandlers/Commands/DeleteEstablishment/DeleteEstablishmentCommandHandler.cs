using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Handlers.EntityHandlers.EstablishmentHandlers.Commands.DeleteEstablishment;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Job;

namespace Wonderworld.Application.Handlers.EstablishmentHandlers.Commands.DeleteEstablishment;

public class DeleteEstablishmentCommandHandler : IRequestHandler<DeleteEstablishmentCommand>
{
    private readonly ISharedLessonDbContext _context;

    public DeleteEstablishmentCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteEstablishmentCommand request, CancellationToken cancellationToken)
    {
        var establishment = await _context.Establishments.FirstOrDefaultAsync(e =>
                e.EstablishmentId == request.EstablishmentId,
            cancellationToken: cancellationToken);

        if (establishment == null)
        {
            throw new NotFoundException(nameof(Establishment), request.EstablishmentId);
        }

        await RemoveCountry(establishment, cancellationToken);

        return Unit.Value;
    }

    private async Task RemoveCountry(Establishment establishment, CancellationToken cancellationToken)
    {
        _context.Establishments.Remove(establishment);
        await _context.SaveChangesAsync(cancellationToken);
    }
}