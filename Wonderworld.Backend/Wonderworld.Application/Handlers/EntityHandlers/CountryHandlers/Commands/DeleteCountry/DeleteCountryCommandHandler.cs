using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Common.Exceptions.Common;
using Wonderworld.Application.Common.Exceptions.Database;
using Wonderworld.Application.Handlers.CountryHandlers.Commands.DeleteCountry;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Application.Handlers.EntityHandlers.CountryHandlers.Commands.DeleteCountry;

public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand>
{
    private readonly ISharedLessonDbContext _context;

    public DeleteCountryCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await _context.Countries!.FirstOrDefaultAsync(t =>
                t.CountryId == request.CountryId,
            cancellationToken: cancellationToken);

        if (country == null)
        {
            throw new NotFoundException(nameof(Country), request.CountryId);
        }

        await RemoveCountry(country, cancellationToken);

        return Unit.Value;
    }

    private async Task RemoveCountry(Country country, CancellationToken cancellationToken)
    {
        _context.Countries!.Remove(country);
        await _context.SaveChangesAsync(cancellationToken);
    }
}