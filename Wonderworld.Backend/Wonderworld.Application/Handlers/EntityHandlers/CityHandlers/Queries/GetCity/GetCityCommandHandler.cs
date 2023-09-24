using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Application.Handlers.EntityHandlers.CityHandlers.Queries.GetCity;

public class GetCityCommandHandler : IRequestHandler<GetCityCommand, City>
{
    private readonly ISharedLessonDbContext _context;

    public GetCityCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<City> Handle(GetCityCommand request, CancellationToken cancellationToken)
    {
        var city = await _context.Cities.FirstOrDefaultAsync(c =>
            c.Country.Title == request.CountryTitle &&
            c.Title == request.Title, cancellationToken: cancellationToken);

        if (city != null)
        {
            return city;
        }

        var newCity = new City()
        {
            Country = new Country()
            {
                Title = request.CountryTitle
            },
            Title = request.Title
        };

        _context.Cities.Add(newCity);
        await _context.SaveChangesAsync(cancellationToken);
        return newCity;
    }
}