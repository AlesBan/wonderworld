using AutoMapper;
using Wonderworld.Application.Common.Mappings;
using Wonderworld.Domain.Entities.Communication;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Dtos.ProfileDtos;

public class UserProfileDto : IMapWith<User>
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PhotoUrl { get; set; } = string.Empty;
    public string BannerPhotoUrl { get; set; } = string.Empty;
    public bool IsATeacher { get; set; }
    public bool IsAnExpert { get; set; }
    public City CityLocation { get; set; } = new();
    public Establishment Establishment { get; set; } = new();
    public double Rating { get; set; }
    public ICollection<Class> Classes { get; set; } = new List<Class>();
    public List<string> Languages { get; set; } = new();
    public List<string> Disciplines { get; set; } = new();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();


    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserProfileDto>()
            .ForMember(up => up.Email,
                opt => opt.MapFrom(u => u.Email))
            .ForMember(up => up.FirstName,
                opt => opt.MapFrom(u => u.FirstName))
            .ForMember(up => up.LastName,
                opt => opt.MapFrom(u => u.LastName))
            .ForMember(up => up.Description,
                opt => opt.MapFrom(u => u.Description))
            .ForMember(up => up.PhotoUrl,
                opt => opt.MapFrom(u => u.PhotoUrl))
            .ForMember(up => up.BannerPhotoUrl,
                opt => opt.MapFrom(u => u.BannerPhotoUrl))
            .ForMember(up => up.IsATeacher,
                opt => opt.MapFrom(u => u.IsATeacher))
            .ForMember(up => up.IsAnExpert,
                opt => opt.MapFrom(u => u.IsAnExpert))
            .ForMember(up => up.CityLocation,
                opt => opt.MapFrom(u => u.CityLocation))
            .ForMember(up => up.Establishment,
                opt => opt.MapFrom(u => u.Establishment))
            .ForMember(up => up.Rating,
                opt => opt.MapFrom(u => u.Rating))
            .ForMember(up => up.Classes,
                opt => opt.MapFrom(u => u.Classes))
            .ForMember(up => up.Languages,
                opt => opt.MapFrom(u => u.UserLanguages.Select(ul => ul.Language)))
            .ForMember(up => up.Disciplines,
                opt => opt.MapFrom(u => u.UserDisciplines.Select(ud => ud.Discipline)))
            .ForMember(up => up.Reviews,
                opt => opt.MapFrom(u => u.ReceivedReviews));
    }
}