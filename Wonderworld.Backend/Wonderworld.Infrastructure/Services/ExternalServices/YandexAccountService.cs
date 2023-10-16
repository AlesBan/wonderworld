using Microsoft.Extensions.Configuration;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Common.Exceptions.Authentication;
using Wonderworld.Application.Common.Exceptions.ExternalServices;
using Wonderworld.Application.Interfaces.Services.ExternalServices;

namespace Wonderworld.Infrastructure.Services.ExternalServices;

public class YandexAccountService : IYandexAccountService
{
    private readonly IConfiguration _configuration;

    public YandexAccountService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GeyAccessToken()
    {
        try
        {
            return _configuration["YandexAccountService:ApiKey"];
        }
        catch (Exception)
        {
            throw new TokenNotFoundException("YandexAccountService:ApiKey");
        }
    }

    public string GetBaseUrl()
    {
        try
        {
            return _configuration["YandexAccountService:BaseUrl"];
        }
        catch (Exception)
        {
            throw new TokenNotFoundException("YandexAccountService:BaseUrl");
        }
    }
}