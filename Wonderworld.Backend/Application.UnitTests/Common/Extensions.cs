namespace Application.UnitTests.Common;

public class Extensions
{
    public static IEnumerable<T> PickRandom<T>(IEnumerable<T> source, int count)
    {
        var random = new Random();
        return source.OrderBy(_ => random.Next())
            .Take(count);
    }
}