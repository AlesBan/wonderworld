using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using MediatR;
using Wonderworld.Application.Common.Mappings;
using Wonderworld.Domain.Entities.Interface;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.MediatorHandlers.UserHandlers.Commands.CreateUserAccount;

public class CreateUserAccountCommand : IRequest, IMapWith<User>
{
    public Guid UserId { get; set; }
    private string? FirstName { get; set; }
    private string? LastName { get; set; }
    private bool IsATeacher { get; set; }
    private bool IsAnExpert { get; set; }
    private InterfaceLanguage? InterfaceLanguage { get; set; }
    private City? CityLocation { get; set; }
    private Establishment? Establishment { get; set; }
    private Appointment? Appointment { get; set; }
    private string? PhotoUrl { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateUserAccountCommand, User>()
            .ForMember(user => user.UserId,
                opt => opt.MapFrom(command => command.UserId))
            .ForMember(user => user.FirstName,
                opt => opt.MapFrom(command => command.FirstName))
            .ForMember(user => user.LastName,
                opt => opt.MapFrom(command => command.LastName))
            .ForMember(user => user.IsATeacher,
                opt => opt.MapFrom(command => command.IsATeacher))
            .ForMember(user => user.IsAnExpert,
                opt => opt.MapFrom(command => command.IsAnExpert))
            .ForMember(user => user.InterfaceLanguage,
                opt => opt.MapFrom(command => command.InterfaceLanguage))
            .ForMember(user => user.CityLocation,
                opt => opt.MapFrom(command => command.CityLocation))
            .ForMember(user => user.Establishment,
                opt => opt.MapFrom(command => command.Establishment))
            .ForMember(user => user.Appointment,
                opt => opt.MapFrom(command => command.Appointment))
            .ForMember(user => user.PhotoUrl,
                opt => opt.MapFrom(command => command.PhotoUrl));
    }
}