using AutoMapper;
using MediatR;
using Wonderworld.Application.Common.Mappings;
using Wonderworld.Domain.Entities.Interface;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.UserHandlers.Commands.UpdateUser;

public class UpdateUserCommand : IRequest, IMapWith<User>
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public bool IsATeacher { get; set; }
    public bool IsAnExpert { get; set; }

    public InterfaceLanguage InterfaceLanguage { get; set; }

    public City CityLocation { get; set; }
    public Establishment Establishment { get; set; }

    public Appointment Appointment { get; set; }

    public string? PhotoUrl { get; set; }
    public string? BannerPhotoUrl { get; set; }

    public string? Aims { get; set; }
    public string? Description { get; set; }

    public bool IsVerified { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateUserCommand, User>()
            .ForMember(user => user.UserId,
                opt => opt.MapFrom(command => command.UserId))
            .ForMember(user => user.FirstName,
                opt => opt.MapFrom(command => command.FirstName))
            .ForMember(user => user.LastName,
                opt => opt.MapFrom(command => command.LastName))
            .ForMember(user => user.Email,
                opt => opt.MapFrom(command => command.Email))
            .ForMember(user => user.Password,
                opt => opt.MapFrom(command => command.Password))
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
                opt => opt.MapFrom(command => command.PhotoUrl))
            .ForMember(user => user.Aims,
                opt => opt.MapFrom(command => command.Aims))
            .ForMember(user => user.Description,
                opt => opt.MapFrom(command => command.Description))
            .ForMember(user => user.BannerPhotoUrl,
                opt => opt.MapFrom(command => command.BannerPhotoUrl))
            .ForMember(user => user.IsVerified,
                opt => opt.MapFrom(command => command.IsVerified));
    }
}