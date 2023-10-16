using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Common.Exceptions.Common;
using Wonderworld.Application.Common.Exceptions.Database;
using Wonderworld.Application.Handlers.EntityHandlers.InstitutionHandlers.Commands.DeleteEstablishment;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Job;

namespace Wonderworld.Application.Handlers.EstablishmentHandlers.Commands.DeleteEstablishment;

public class DeleteInstitutionCommandHandler : IRequestHandler<DeleteInstitutionCommand>
{
    private readonly ISharedLessonDbContext _context;

    public DeleteInstitutionCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteInstitutionCommand request, CancellationToken cancellationToken)
    {
        var establishment = await _context.Institutions.FirstOrDefaultAsync(e =>
                e.InstitutionId == request.EstablishmentId,
            cancellationToken: cancellationToken);

        if (establishment == null)
        {
            throw new NotFoundException(nameof(Institution), request.EstablishmentId);
        }

        await RemoveCountry(establishment, cancellationToken);

        return Unit.Value;
    }

    private async Task RemoveCountry(Institution establishment, CancellationToken cancellationToken)
    {
        _context.Institutions.Remove(establishment);
        await _context.SaveChangesAsync(cancellationToken);
    }
}