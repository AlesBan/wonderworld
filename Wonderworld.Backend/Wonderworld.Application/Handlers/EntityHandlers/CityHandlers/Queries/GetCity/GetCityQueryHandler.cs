using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Application.Handlers.EntityHandlers.CityHandlers.Queries.GetCity;

public class GetCityQueryHandler : IRequestHandler<GetCityQuery, City>
{
    private readonly ISharedLessonDbContext _context;

    public GetCityQueryHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<City> Handle(GetCityQuery request, CancellationToken cancellationToken)
    {
        var city = await _context.Cities.FirstOrDefaultAsync(c =>
            c.Country.CountryId == request.CountryId &&
            c.Title == request.Title, cancellationToken: cancellationToken);

        if (city == null)
        {
            throw new NotFoundException(nameof(City), request.Title);
        }

        return city;
    }
}