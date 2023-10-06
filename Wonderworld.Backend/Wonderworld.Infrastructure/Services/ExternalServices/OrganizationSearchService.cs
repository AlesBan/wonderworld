using System.Net.Http.Json;
using System.Text.Json;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Dtos.CreateAccountDtos;
using Wonderworld.Application.Interfaces.Services.ExternalServices;
using Wonderworld.Infrastructure.Models.YandexOrganizationSearch;

namespace Wonderworld.Infrastructure.Services.ExternalServices;

public class OrganizationSearchService : IOrganizationSearchService
{
    private readonly IYandexAccountService _yandexAccountService;
    private readonly HttpClient _httpClient;

    public OrganizationSearchService(IYandexAccountService yandexAccountService, HttpClient httpClient)
    {
        _yandexAccountService = yandexAccountService;
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<InstitutionSearchResponseDto>> GetEstablishments(InstitutionDto establishment)
    {
        var token = _yandexAccountService.GeyAccessToken();
        var baseUrl = _yandexAccountService.GetBaseUrl();

        var requestText = string.Join(' ', establishment.Types) + " " +
                          establishment.Title;

        var requestUrl = baseUrl +
                         "apikey=" + token +
                         "&text=" + requestText +
                         "&lang=en_US" +
                         "&type=biz" +
                         "&results=" + ExternalServicesConstants.SearchLimit;

        var response = await GetResponse(requestUrl);

        var responseObject = await DeserializationAsync<Root>(response);

        if (responseObject == null)
        {
            return new List<InstitutionSearchResponseDto>();
        }

        var establishmentSearchDtoList = GetEstablishmentSearchDtoList(responseObject);
        return establishmentSearchDtoList;
    }

    private static IEnumerable<InstitutionSearchResponseDto> GetEstablishmentSearchDtoList(Root responseObject)
    {
        var establishmentSearchDtoList = responseObject.Features.Select(f =>
            new InstitutionSearchResponseDto()
            {
                Title = f.Properties.Name + " " +
                        f.Properties.Description + " " +
                        string.Join(' ', f.Properties.CompanyMetaData.Categories.ToList().Select(c => c.Name).ToList())
            });

        return establishmentSearchDtoList;
    }

    private async Task<HttpResponseMessage> GetResponse(string requestMessage)
    {
        var response = await _httpClient.GetAsync(requestMessage);
        // CheckResponse(response);
        return response;
    }

    private void CheckResponse(HttpResponseMessage response)
    {
        throw new NotImplementedException();
    }

    private static async Task<T?> DeserializationAsync<T>(HttpResponseMessage response)
    {
        T? responseObj;
        try
        {
            responseObj = await response.Content.ReadFromJsonAsync<T>();
        }
        catch (JsonException ex)
        {
            throw new DeserializationOfYandexResponseException(ex.Message);
        }

        return responseObj;
    }
}