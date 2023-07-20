using MediatR;
using Wonderworld.Domain.Entities.Interface;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Application.MediatorHandlers.UserHandlers.Commands.UpdateTeacher;

public class UpdateUserCommand : IRequest
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
}