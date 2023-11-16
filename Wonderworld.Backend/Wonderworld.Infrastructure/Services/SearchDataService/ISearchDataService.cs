using MediatR;
using Wonderworld.Application.Dtos;

namespace Wonderworld.Infrastructure.Services.SearchDataService;

public interface ISearchDataService
{
    Task<ExistingCountriesDto> GetAllCounties(IMediator mediator);
}