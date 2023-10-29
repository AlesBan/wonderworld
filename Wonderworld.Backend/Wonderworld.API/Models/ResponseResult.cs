namespace Wonderworld.API.Models;

public class ResponseResult
{
    public bool Result { get; set; }
    public List<string> Errors { get; set; }
    
    public object? Value { get; set; }
}