using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Application.Handlers.EstablishmentHandlers.Commands.CreateEstablishment;

public class CreateEstablishmentCommandHandler: IRequestHandler<CreateEstablishmentCommand, Guid>
{
    private readonly ISharedLessonDbContext _context;

    public CreateEstablishmentCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateEstablishmentCommand request, CancellationToken cancellationToken)
    {
        var city = await _context.Cities.FirstOrDefaultAsync(t =>
            t.CityId == request.City.CityId, 
            cancellationToken: cancellationToken);

        if (city == null)
        {
            throw new NotFoundException(nameof(City), request.City.CityId);
        }

        var establishment = new Establishment()
        {
            Type = request.Type,
            Title = request.Title,
            City = city
        };

        await AddEstablishment(establishment, cancellationToken);

        return await Task.FromResult(establishment.EstablishmentId);
    }
    private async Task AddEstablishment(Establishment establishment, CancellationToken cancellationToken)
    {
        await _context.Establishments.AddAsync(establishment, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}