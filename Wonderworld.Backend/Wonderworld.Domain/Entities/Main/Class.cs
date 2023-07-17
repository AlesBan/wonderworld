namespace Wonderworld.Domain.Entities.Main;

public class Class
{
    public Guid ClassId { get; set; }
    
    public int ClassNumber { get; set; }
    public int ClassAge { get; set; }
    
    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; }
}