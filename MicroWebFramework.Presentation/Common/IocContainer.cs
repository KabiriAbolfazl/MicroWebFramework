using Microsoft.Extensions.DependencyInjection;


namespace MicroWebFramework.Presentation.Common;

public static class IocContainer
{
    private static ServiceProvider _serviceProvider;
    private static IServiceCollection _services;
    static IocContainer()
    {
        _services = new ServiceCollection();
    }

    public static void AddTransient(Type service, Type implementation)
    {
        _services.AddTransient(service, implementation);
    }

    public static void AddScoped(Type service, Type implementation)
    {
        _services.AddScoped(service, implementation);
    }

    public static void AddSingleton(Type service, Type implementation)
    {
        _services.AddSingleton(service, implementation);
    }

    public static void AddServiceProvider()
    {
        _serviceProvider = _services.BuildServiceProvider();
    }

    public static object GetServiceImplementation(Type service)
    {
        if (_serviceProvider is null)
            throw new ArgumentNullException(nameof(_serviceProvider));

        if (service is null)
            throw new ArgumentNullException(nameof(service));

        return _serviceProvider.GetService(service);
    }
}
