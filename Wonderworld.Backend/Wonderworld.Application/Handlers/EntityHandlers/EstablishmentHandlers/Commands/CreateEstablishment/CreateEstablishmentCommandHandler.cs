using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityHandlers.EstablishmentHandlers.Commands.CreateEstablishment;

public class CreateEstablishmentCommandHandler : IRequestHandler<CreateEstablishmentCommand, Establishment>
{
    private readonly ISharedLessonDbContext _context;

    public CreateEstablishmentCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Establishment> Handle(CreateEstablishmentCommand request, CancellationToken cancellationToken)
    {
        var establishment = await _context.Establishments
            .FirstOrDefaultAsync(e =>
                    e.Address == request.Address,
                cancellationToken: cancellationToken);

        if (establishment != null)
        {
            return establishment;
        }

        var newEstablishment = new Establishment()
        {
            Title = request.Title,
            Address = request.Address
        };

        await AddEstablishment(newEstablishment, cancellationToken);
        
        var types = _context.EstablishmentTypes
            .Where(et =>
                request.Types
                    .Contains(et));
        await AddEstablishmentTypeEstablishment(newEstablishment, types, cancellationToken);


        return newEstablishment;
    }

    private async Task AddEstablishment(Establishment establishment, CancellationToken cancellationToken)
    {
        await _context.Establishments
            .AddAsync(establishment, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    private async Task AddEstablishmentTypeEstablishment(Establishment establishment,
        IEnumerable<EstablishmentType> types, CancellationToken cancellationToken)
    {
        var establishmentTypes = types
            .Select(type =>
                new EstablishmentTypeEstablishment
                {
                    EstablishmentId = establishment.EstablishmentId,
                    EstablishmentTypeId = type.EstablishmentTypeId
                }).ToList();

        await _context.EstablishmentTypesEstablishments
            .AddRangeAsync(establishmentTypes, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }
}