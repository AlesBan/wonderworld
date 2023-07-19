using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Domain.Entities.Interface;

public class InterfaceLanguage
{
    public Guid LanguageId { get; set; }
    
    public string Title { get; set; }
    
    public ICollection<Teacher> Teachers { get; set; }

}