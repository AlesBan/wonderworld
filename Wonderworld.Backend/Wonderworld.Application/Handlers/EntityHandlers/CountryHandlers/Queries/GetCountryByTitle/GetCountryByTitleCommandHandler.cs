using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Application.Handlers.EntityHandlers.CountryHandlers.Queries.GetCountryByTitle;

public class GetCountryByTitleCommandHandler : IRequestHandler<GetCountryByTitleCommand, Country>
{
    private readonly ISharedLessonDbContext _context;

    public GetCountryByTitleCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Country> Handle(GetCountryByTitleCommand request, CancellationToken cancellationToken)
    {
        var country = await _context.Countries
            .FirstOrDefaultAsync(c =>
                c.Title == request.Title, cancellationToken: cancellationToken);

        if (country == null)
        {
            throw new NotFoundException(nameof(Country), request.Title);
        }

        return country;
    }
}