namespace Wonderworld.Domain.Entities;

public class Language
{
    public Guid LanguageId { get; set; }
    
    public string Title { get; set; }
    
    public bool CanBeInterfaceLanguage { get; set; }
}