using MediatR;

namespace Wonderworld.Application.MediatorHandlers.Teacher.Commands.CreateTeacher;

public class CreateTeacherCommand : IRequest<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public bool IsATeacher { get; set; }
    public bool IsAnExpert { get; set; }
    
    public string PhotoUrl { get; set; }
    
    public string Description { get; set; }
    public string Aims { get; set; }
    
    public Guid EstablishmentId { get; set; }
    public Guid InterfaceLanguageId { get; set; }
    

}