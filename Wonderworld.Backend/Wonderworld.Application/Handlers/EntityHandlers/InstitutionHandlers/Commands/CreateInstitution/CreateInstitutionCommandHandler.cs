using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Handlers.EntityHandlers.InstitutionHandlers.Commands.CreateInstitution;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityHandlers.InstitutionHandlers.Commands.CreateEstablishment;

public class CreateInstitutionCommandHandler : IRequestHandler<CreateInstitutionCommand, Institution>
{
    private readonly ISharedLessonDbContext _context;

    public CreateInstitutionCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Institution> Handle(CreateInstitutionCommand request, CancellationToken cancellationToken)
    {
        var establishment = await _context.Institutions
            .FirstOrDefaultAsync(e =>
                    e.Address == request.Address,
                cancellationToken: cancellationToken);

        if (establishment != null)
        {
            return establishment;
        }

        var newEstablishment = new Institution()
        {
            Title = request.Title,
            Address = request.Address
        };

        await AddInstitution(newEstablishment, cancellationToken);
        
        var types = _context.InstitutionTypes
            .Where(et =>
                request.Types
                    .Contains(et.Title));
        await AddInstitutionTypeInstitution(newEstablishment, types, cancellationToken);

        return newEstablishment;
    }

    private async Task AddInstitution(Institution establishment, CancellationToken cancellationToken)
    {
        await _context.Institutions
            .AddAsync(establishment, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    private async Task AddInstitutionTypeInstitution(Institution establishment,
        IEnumerable<InstitutionType> types, CancellationToken cancellationToken)
    {
        var establishmentTypes = types
            .Select(type =>
                new InstitutionTypeInstitution
                {
                    InstitutionId = establishment.InstitutionId,
                    InstitutionTypeId = type.InstitutionTypeId
                }).ToList();

        await _context.InstitutionTypesInstitutions
            .AddRangeAsync(establishmentTypes, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }
}