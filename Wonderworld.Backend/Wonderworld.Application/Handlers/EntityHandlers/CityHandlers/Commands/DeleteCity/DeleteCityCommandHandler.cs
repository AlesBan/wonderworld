using MediatR;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Common.Exceptions.Common;
using Wonderworld.Application.Common.Exceptions.Database;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Application.Handlers.EntityHandlers.CityHandlers.Commands.DeleteCity;

public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand>
{
    private readonly ISharedLessonDbContext _context;

    public DeleteCityCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
    {
        var city = _context.Cities!.FirstOrDefault(t =>
            t.CityId == request.CityId);

        if (city == null)
        {
            throw new NotFoundException(nameof(City), request.CityId);
        }

        await RemoveCity(city, cancellationToken);
        _context.Cities.Remove(city);
        
        return Unit.Value;
    }

    private async Task RemoveCity(City city, CancellationToken cancellationToken)
    {
         _context.Cities!.Remove(city);
        await _context.SaveChangesAsync(cancellationToken);
    }
}