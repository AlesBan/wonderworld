using Wonderworld.Application.Dtos.CreateAccountDtos;

namespace Wonderworld.Application.Interfaces.Services.ExternalServices;

public interface IOrganizationSearchService
{
    public Task<IEnumerable<EstablishmentSearchResponseDto>> GetEstablishments(EstablishmentDto establishment);
}