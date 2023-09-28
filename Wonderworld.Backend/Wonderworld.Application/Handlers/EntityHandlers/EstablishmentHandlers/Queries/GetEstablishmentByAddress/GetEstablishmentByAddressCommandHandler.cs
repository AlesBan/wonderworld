using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityHandlers.EstablishmentHandlers.Queries.GetEstablishmentByAddress;

public class GetEstablishmentByAddressCommandHandler : IRequestHandler<GetEstablishmentCommand, Establishment>
{
    private readonly ISharedLessonDbContext _context;

    public GetEstablishmentByAddressCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Establishment> Handle(GetEstablishmentCommand request,
        CancellationToken cancellationToken)
    {
        var establishment = await _context.Establishments
            .FirstOrDefaultAsync(e =>
                e.Address == request.Address, cancellationToken: cancellationToken);

        if (establishment != null)
        {
            return establishment;
        }

        var newEstablishment = new Establishment()
        {
            Address = request.Address,
            Title = request.Title
        };

        var establishmentTypesEstablishments = request.Types
            .Select(t =>
                new EstablishmentTypeEstablishment()
                {
                    EstablishmentType = t,
                    Establishment = newEstablishment
                });

        await _context.EstablishmentTypesEstablishments.AddRangeAsync(establishmentTypesEstablishments,
            cancellationToken);
        await _context.Establishments.AddAsync(newEstablishment, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return newEstablishment;
    }
}