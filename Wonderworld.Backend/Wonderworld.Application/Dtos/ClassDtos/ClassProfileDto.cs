using AutoMapper;
using Wonderworld.Application.Common.Mappings;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Dtos.ClassDtos;

public class ClassProfileDto : IMapWith<Class>
{
    public Guid ClassId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string UserFullName { get; set; } = string.Empty;
    public double UserRating { get; set; }
    public int UserReviewsCount { get; set; }
    public int Grade { get; set; }
    public List<string> Languages { get; set; } = new();
    public List<string> Disciplines { get; set; } = new();
    public string PhotoUrl { get; set; } = string.Empty;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Class, Grade>()
            .ForMember(up => up.GradeNumber,
                opt => opt.MapFrom(u => u.Grade));
        profile.CreateMap<Class, ClassProfileDto>()
            .ForMember(cp => cp.ClassId,
                opt => opt.MapFrom(u => u.ClassId))
            .ForMember(up => up.Title,
                opt => opt.MapFrom(u => u.Title))
            .ForMember(up => up.UserFullName,
                opt => opt.MapFrom(u =>
                    u.User.FirstName + " " + u.User.LastName))
            .ForMember(up => up.UserRating,
                opt => opt.MapFrom(u => u.User.Rating))
            .ForMember(up => up.UserReviewsCount,
                opt => opt.MapFrom(u => u.User.ReceivedReviews.Count))
            .ForMember(up => up.Grade,
                opt => opt.MapFrom(u => u.Grade.GradeNumber))
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