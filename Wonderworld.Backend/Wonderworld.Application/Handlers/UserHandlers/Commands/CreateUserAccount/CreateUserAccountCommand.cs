using AutoMapper;
using MediatR;
using Wonderworld.Application.Common.Mappings;
using Wonderworld.Domain.Entities.Interface;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.UserHandlers.Commands.CreateUserAccount;

public class CreateUserAccountCommand : IRequest, IMapWith<User>
{
    public Guid UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool IsATeacher { get; set; }
    public bool IsAnExpert { get; set; }
    public InterfaceLanguage InterfaceLanguage { get; set; }
    public City? CityLocation { get; set; }
    public Establishment? Establishment { get; set; }
    public Appointment? Appointment { get; set; }
    public string? PhotoUrl { get; set; }
}