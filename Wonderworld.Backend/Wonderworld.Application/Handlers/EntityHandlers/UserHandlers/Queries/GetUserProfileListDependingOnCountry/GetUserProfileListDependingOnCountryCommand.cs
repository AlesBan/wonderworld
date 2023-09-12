using MediatR;
using Wonderworld.Application.Dtos.ProfileDtos;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListDependingOnCountry;

public class GetUserProfileListDependingOnCountryCommand : IRequest<IEnumerable<UserProfileDto>>
{
    public Guid CountryId { get; set; }
    public bool IsATeacher { get; set; }
    public bool IsAnExpert { get; set; }
}