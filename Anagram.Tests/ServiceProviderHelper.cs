using Microsoft.Extensions.DependencyInjection;

namespace Anagram.UnitTests;

public static class ServiceProviderHelper
{
    public static IServiceProvider Provider { private set; get; }

    static ServiceProviderHelper()
    {
        Provider = BuildServiceProvider();
    }

    private static IServiceProvider BuildServiceProvider()
    {
        var serviceCollection = new ServiceCollection()
            .AddSingleton<AnagramCheckerComputeKey>()
            .AddSingleton<AnagramCheckerOrderBy>()
            .AddSingleton<IWordKeyGenerator, WordKeyGenerator>();
        
        return serviceCollection.BuildServiceProvider();
    }
}