using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Handlers.EntityHandlers.InstitutionHandlers.Commands.CreateInstitution;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Job;

namespace Wonderworld.Application.Handlers.EntityHandlers.InstitutionHandlers.Queries.GetEstablishment;

public class GetInstitutionQueryHandler : IRequestHandler<GetInstitutionQuery, Institution>
{
    private readonly ISharedLessonDbContext _context;
    private readonly IMediator _mediator;

    public GetInstitutionQueryHandler(ISharedLessonDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Institution> Handle(GetInstitutionQuery request,
        CancellationToken cancellationToken)
    {
        var institution = await _context.Institutions
            .FirstOrDefaultAsync(e =>
                e.Address == request.Address, cancellationToken: cancellationToken);
        
        if (institution != null)
        {
           return institution;
        }
        
        var newInstitution = await _mediator.Send(
            new CreateInstitutionCommand
            {
                Types = request.Types,
                InstitutionTitle = request.InstitutionTitle,
                Address = request.Address
            }, cancellationToken);
        
        await _context.Institutions.AddAsync(newInstitution, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken: cancellationToken);
        return newInstitution;
    }
}