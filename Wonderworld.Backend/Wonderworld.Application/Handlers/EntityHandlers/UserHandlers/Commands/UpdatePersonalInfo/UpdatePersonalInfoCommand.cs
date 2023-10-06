using System.ComponentModel.DataAnnotations;
using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdatePersonalInfo;

public class UpdatePersonalInfoCommand : IRequest<User>
{
    [Required] public Guid UserId { get; set; }
    [Required] public bool IsATeacher { get; set; }
    [Required] public bool IsAnExpert { get; set; }
    [Required] public string FirstName { get; set; } = string.Empty;
    [Required] public string LastName { get; set; } = string.Empty;
    [Required] public string CityTitle { get; set; } = string.Empty;
    [Required] public string CountryTitle { get; set; } = string.Empty;
    [Required] public string Description { get; set; } = string.Empty;
}