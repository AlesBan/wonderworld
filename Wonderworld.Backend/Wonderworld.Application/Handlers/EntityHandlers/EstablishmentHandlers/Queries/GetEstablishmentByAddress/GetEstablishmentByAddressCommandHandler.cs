using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityHandlers.EstablishmentHandlers.Queries.GetEstablishmentByAddress;

public class GetEstablishmentCommandHandler : IRequestHandler<GetEstablishmentCommand, Establishment>
{
    private readonly ISharedLessonDbContext _context;

    public GetEstablishmentCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Establishment> Handle(GetEstablishmentCommand request,
        CancellationToken cancellationToken)
    {
        var establishment = await _context.Establishments
            .FirstOrDefaultAsync(e =>
                e.Address == request.Address, cancellationToken: cancellationToken);

        if (establishment == null)
        {
            throw new NotFoundException(nameof(Establishment), request.Address);
        }

        return establishment;
    }
}