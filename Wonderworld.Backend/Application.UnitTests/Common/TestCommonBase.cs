using Wonderworld.Persistence;

namespace Application.UnitTests.Common;

public abstract class TestCommonBase : IDisposable
{
    protected readonly SharedLessonDbContext Context;

    public TestCommonBase()
    {
        Context = SharedLessonDbContextFactory.Create();
    }

    public void Dispose()
    {
        SharedLessonDbContextFactory.Destroy(Context);
        GC.SuppressFinalize(this);
    }
}