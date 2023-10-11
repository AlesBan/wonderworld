using Microsoft.AspNetCore.Mvc;
using Wonderworld.Application.Dtos.CreateAccountDtos;
using Wonderworld.Application.Interfaces.Services.ExternalServices;

namespace Wonderworld.API.Controllers;

public class OrganizationSearchController : BaseController
{
    private readonly IOrganizationSearchService _organizationSearchService;

    public OrganizationSearchController(IOrganizationSearchService organizationSearchService)
    {
        _organizationSearchService = organizationSearchService;
    }

    [HttpGet("get-establishments")]
    public async Task<IEnumerable<InstitutionSearchResponseDto>> GetEstablishments(
        [FromQuery] InstitutionDto establishment)
    {
        var result = await _organizationSearchService.GetInstitutions(establishment);
        return result;
    }
}