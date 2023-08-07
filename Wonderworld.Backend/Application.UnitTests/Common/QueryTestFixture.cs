using AutoMapper;
using Wonderworld.Application.Common.Mappings;
using Wonderworld.Application.Interfaces;
using Wonderworld.Persistence;
using Xunit;

namespace Application.UnitTests.Common;

public class QueryTestFixture : IDisposable
{
    public readonly SharedLessonDbContext Context;
    public readonly IMapper Mapper;

    public QueryTestFixture()
    {
        Context = SharedLessonDbContextFactory.Create();
        var configProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(ISharedLessonDbContext).Assembly));
        });
        
        Mapper = configProvider.CreateMapper();
    }

    public void Dispose()
    {
        SharedLessonDbContextFactory.Destroy(Context);
    }
}

[CollectionDefinition("QueryCollection")]
public class QueryCollection : ICollectionFixture<QueryTestFixture>
{
}