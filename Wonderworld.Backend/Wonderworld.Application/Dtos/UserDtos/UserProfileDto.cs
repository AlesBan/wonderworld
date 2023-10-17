using AutoMapper;
using Wonderworld.Application.Common.Mappings;
using Wonderworld.Application.Dtos.ClassDtos;
using Wonderworld.Application.Dtos.CreateAccountDtos;
using Wonderworld.Application.Dtos.InstitutionDtos;
using Wonderworld.Domain.Entities.Communication;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Dtos.UserDtos;

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
    public string CityTitle { get; set; } = string.Empty;
    public string CountryTitle { get; set; } = string.Empty;
    public InstitutionDto Institution { get; set; }
    public double Rating { get; set; }
    public IEnumerable<ClassProfileDto> ClasseDtos { get; set; } = new List<ClassProfileDto>();
    public List<string> LanguageTitles { get; set; } = new();
    public List<string> DisciplineTitles { get; set; } = new();
    public List<int> GradeNumbers { get; set; } = new();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();

    public void Mapping(Profile profile)
    {
        profile.CreateMap<City, UserProfileDto>()
            .ForMember(up => up.CityTitle,
                opt => opt.MapFrom(c => c.Title));
        profile.CreateMap<Country, UserProfileDto>()
            .ForMember(up => up.CountryTitle,
                opt => opt.MapFrom(c => c.Title));
        profile.CreateMap<Institution, InstitutionDto>()
            .ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Title,
                opt => opt.MapFrom(src => src.Title));
        profile.CreateMap<User, UserProfileDto>()
            .ForMember(up => up.UserId,
                opt => opt.MapFrom(u => u.UserId))
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
            .ForMember(up => up.Rating,
                opt => opt.MapFrom(u => u.Rating))
            .ForMember(up => up.CityTitle,
                opt => opt.MapFrom(c => c.City.Title))
            .ForMember(up => up.CountryTitle,
                opt => opt.MapFrom(c => c.Country.Title))
            .ForMember(dest => dest.Institution,
                opt => opt.MapFrom(src => new InstitutionDto
                {
                    Address = src.Institution.Address,
                    Title = src.Institution.Title,
                }));
    }
}