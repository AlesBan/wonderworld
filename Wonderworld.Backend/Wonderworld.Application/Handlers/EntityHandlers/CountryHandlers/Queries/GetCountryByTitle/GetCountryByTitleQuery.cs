using MediatR;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Application.Handlers.EntityHandlers.CountryHandlers.Queries.GetCountryByTitle;

public class GetCountryByTitleQuery : IRequest<Country>
{
    public string Title { get; set; }

    public GetCountryByTitleQuery(string title) 
    {
        Title = title;
    }
}