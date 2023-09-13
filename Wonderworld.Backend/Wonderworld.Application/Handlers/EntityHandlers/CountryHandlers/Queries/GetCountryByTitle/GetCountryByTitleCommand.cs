using MediatR;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Application.Handlers.EntityHandlers.CountryHandlers.Queries.GetCountryByTitle;

public class GetCountryByTitleCommand : IRequest<Country>
{
    public string Title { get; set; }
}