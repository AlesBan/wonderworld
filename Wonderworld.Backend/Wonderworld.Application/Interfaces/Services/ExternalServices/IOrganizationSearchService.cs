using Wonderworld.Application.Dtos.CreateAccountDtos;
using Wonderworld.Application.Dtos.InstitutionDtos;

namespace Wonderworld.Application.Interfaces.Services.ExternalServices;

public interface IOrganizationSearchService
{
    public Task<IEnumerable<InstitutionSearchResponseDto>> GetInstitutions(InstitutionDto establishment);
}