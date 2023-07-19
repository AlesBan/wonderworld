namespace Wonderworld.Persistence;

public static class DbInitializer
{
    public static void Initialize(WonderworldDbContext context)
    {
        context.Database.EnsureCreated();
    }
}