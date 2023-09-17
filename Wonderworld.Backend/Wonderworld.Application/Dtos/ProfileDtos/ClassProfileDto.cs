using AutoMapper;
using Wonderworld.Application.Common.Mappings;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Dtos.ProfileDtos;

public class ClassProfileDto : IMapWith<Class>
{
    public Guid ClassId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string UserFullName { get; set; } = string.Empty;
    public double UserRating { get; set; }
    public int UserReviewsCount { get; set; }
    public Grade Grade { get; set; } = new();
    public int Age { get; set; }
    public List<string> Languages { get; set; } = new();
    public List<string> Disciplines { get; set; } = new();
    public string PhotoUrl { get; set; } = string.Empty;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Class, ClassProfileDto>()
            .ForMember(up => up.ClassId,
                opt => opt.MapFrom(u => u.ClassId))
            .ForMember(up => up.Title,
                opt => opt.MapFrom(u => u.Title))
            .ForMember(up => up.UserFullName,
                opt => opt.MapFrom(u =>
                    u.User.FullName))
            .ForMember(up => up.UserRating,
                opt => opt.MapFrom(u => u.User.Rating))
            .ForMember(up => up.UserReviewsCount,
                opt => opt.MapFrom(u => u.User.ReceivedReviews.Count))
            .ForMember(up => up.Grade,
                opt => opt.MapFrom(u => u.Grade))
            .ForMember(up => up.Age,
                opt => opt.MapFrom(u => u.Age))
            .ForMember(up => up.PhotoUrl,
                opt => opt.MapFrom(u => u.PhotoUrl))
            .ForMember(up => up.Languages,
                opt => opt.MapFrom(u => u.ClassLanguages.Select(cl =>
                    cl.Language.Title)))
            .ForMember(up => up.Disciplines,
                opt => opt.MapFrom(u => u.ClassDisciplines.Select(cd =>
                    cd.Discipline.Title)));
    }
}