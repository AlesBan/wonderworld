namespace Wonderworld.Application.Dtos.CreateAccountDtos;

public class EstablishmentDto
{
    public string Type { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string CityTitle { get; set; } = string.Empty;
    public string CountryTitle { get; set; } = string.Empty;
    public string SearchLanguage { get; set; } = string.Empty;
    public string Title => $"{Type} {Number}";
}