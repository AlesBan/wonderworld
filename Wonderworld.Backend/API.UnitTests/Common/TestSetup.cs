using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.UnitTests.Common;

public class TestSetup
{
    public TestSetup()
    {
        var serviceCollection = new ServiceCollection();
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(
                path: "appsettings.test.json",
                optional: false,
                reloadOnChange: true)
            .Build();
        serviceCollection.AddSingleton<IConfiguration>(configuration);

        ServiceProvider = serviceCollection.BuildServiceProvider();
    }

    public ServiceProvider ServiceProvider { get; private set; }
}