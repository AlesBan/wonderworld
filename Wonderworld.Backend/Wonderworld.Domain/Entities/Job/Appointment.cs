using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Domain.Entities.Job;

public class Appointment
{
    public Guid AppointmentId { get; set; }
    
    public string Title { get; set; }
    
    public ICollection<User> Teachers { get; set; }
}