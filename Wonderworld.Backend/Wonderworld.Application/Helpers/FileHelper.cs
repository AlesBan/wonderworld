namespace Wonderworld.Application.Helpers;

public static class FileHelper
{
    public static List<string> GetLines(string path)
    {
        var lines = new List<string>();

        var fileLines = File.ReadAllLines(path);
        try
        {
            lines.AddRange(fileLines.Select(line => line.Trim()).Where(cleanedLine => !string.IsNullOrEmpty(cleanedLine)));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
        }

        return lines;
    }
}