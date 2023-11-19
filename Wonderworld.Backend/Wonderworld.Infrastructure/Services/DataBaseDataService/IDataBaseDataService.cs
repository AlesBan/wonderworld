using MediatR;
using Wonderworld.Application.Dtos;

namespace Wonderworld.Infrastructure.Services.DataBaseDataService;

public interface IDataBaseDataService
{
    Task<ExistingCountriesDto> GetAllCounties(IMediator mediator);
}