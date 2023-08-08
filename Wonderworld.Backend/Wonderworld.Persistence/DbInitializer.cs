namespace Wonderworld.Persistence;

public static class DbInitializer
{
    public static void Initialize(SharedLessonDbContext context)
    {
        context.Database.EnsureCreated();
    }
}