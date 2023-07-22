using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Application.Handlers.CountryHandlers.Commands.CreateCountry;

public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Guid>
{
    private readonly ISharedLessonDbContext _context;

    public CreateCountryCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = new Country()
        {
            Title = request.Title
        };

        await AddCountry(country, cancellationToken);
        return await Task.FromResult(country.CountryId);
    }

    private async Task AddCountry(Country country, CancellationToken cancellationToken)
    {
        await _context.Countries.AddAsync(country, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}