using MediatR;
using Wonderworld.Application.Dtos.ProfileDtos;

namespace Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Queries.GetClassProfileListDependingOnCountry;

public class GetClassProfileListDependingOnCountryCommand : IRequest<IEnumerable<ClassProfileDto>>
{
    public Guid CountryId { get; set; }

}