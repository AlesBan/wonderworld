using MediatR;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserCityLocation;

public class UpdateUserCityLocationCommand : IRequest
{
    public User User { get; set; }
    public City CityLocation { get; set; }
}