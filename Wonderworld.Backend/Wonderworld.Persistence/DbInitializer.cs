namespace Wonderworld.Persistence;

public static class DbInitializer
{
    public static void Initialize(SharedLessonContext context)
    {
        context.Database.EnsureCreated();
    }
}