namespace Wonderworld.Persistence;

public static class DbInitializer
{
    public static void Initialize(ServiceDbContext context)
    {
        context.Database.EnsureCreated();
    }
}