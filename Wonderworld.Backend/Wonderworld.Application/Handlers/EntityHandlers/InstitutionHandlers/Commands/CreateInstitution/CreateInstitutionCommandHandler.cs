using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityHandlers.InstitutionHandlers.Commands.CreateInstitution;

public class CreateInstitutionCommandHandler : IRequestHandler<CreateInstitutionCommand, Institution>
{
    private readonly ISharedLessonDbContext _context;

    public CreateInstitutionCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Institution> Handle(CreateInstitutionCommand request, CancellationToken cancellationToken)
    {
        var institution = await _context.Institutions
            .FirstOrDefaultAsync(e =>
                    e.Address == request.Address,
                cancellationToken: cancellationToken);

        if (institution != null)
        {
            return institution;
        }

        var newInstitution = new Institution()
        {
            Title = request.InstitutionTitle,
            Address = request.Address
        };

        await AddInstitution(newInstitution, cancellationToken);
        
        var types = _context.InstitutionTypes
            .Where(et =>
                request.Types
                    .Contains(et.Title));
        await AddInstitutionTypeInstitution(newInstitution, types, cancellationToken);

        return newInstitution;
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