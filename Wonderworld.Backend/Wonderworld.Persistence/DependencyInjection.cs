using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wonderworld.Application.Interfaces;

namespace Wonderworld.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<ISharedLessonDbContext, SharedLessonDbContext>();
        
        var connection = configuration.GetConnectionString("DefaultConnection");
        services.AddEntityFrameworkNpgsql()
            .AddDbContext<SharedLessonDbContext>(options =>
                {
                    options.UseNpgsql(connection);
                    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

                }
            );
        
        return services;
    }
}