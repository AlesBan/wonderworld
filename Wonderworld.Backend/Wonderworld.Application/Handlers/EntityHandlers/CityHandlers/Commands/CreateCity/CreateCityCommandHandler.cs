using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Application.Handlers.EntityHandlers.CityHandlers.Commands.CreateCity;

public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, Guid>
{
    private readonly ISharedLessonDbContext _context;

    public CreateCityCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        var country = await _context.Countries!.FirstOrDefaultAsync(t =>
            t.CountryId == request.Country.CountryId, cancellationToken);

        if (country == null)
        {
            throw new NotFoundException(nameof(Country), request.Country.CountryId);
        }

        var city = new City()
        {
            Title = request.Title,
            Country = country
        };

        await AddCity(city, cancellationToken);

        return await Task.FromResult(city.CityId);
    }

    private async Task AddCity(City city, CancellationToken cancellationToken)
    {
        await _context.Cities.AddAsync(city, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}