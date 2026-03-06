namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for setting up dependency injection in an <see cref="IServiceCollection" />
/// and an <see cref="IServiceProvider" />.
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddWeatherServices(this IServiceCollection services)
    {
        services.AddTransient<IWeatherClient, WeatherClient>();
        services.AddTransient<IWeatherService, WeatherService>();
        return services;
    }
}